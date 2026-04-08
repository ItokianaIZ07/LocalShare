using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace LocalShare.Core
{
    public class ConnectionManager
    {
        public int Port { get; private set; }
        private TcpListener server;
        private ConcurrentDictionary<string, TcpClient> clients;
        private Dictionary<string, string> pseudos;
        private FileManager FileManager { get; set; }

        public ConnectionManager(int port, FileManager fileManager)
        {
            Port = port;
            clients = new ConcurrentDictionary<string, TcpClient>();
            pseudos = new Dictionary<string, string>();
            FileManager = fileManager;
        }

        public void StartServer()
        {
            server = new TcpListener(IPAddress.Any, Port);
            server.Start();

            Logger.Log($"Server started on port {Port}");

            new Thread(AcceptClients) { IsBackground = true }.Start();
        }

        private void AcceptClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                clients.TryAdd(clientKey, client);

                lock (pseudos)
                {
                    pseudos[clientKey] = "Unknown";
                }

                Logger.Log($"Client connected: {clientKey}");

                new Thread(() => HandleClient(client)) { IsBackground = true }.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            NetworkStream stream = client.GetStream();

            try
            {
                byte[] buffer = new byte[4096];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // 🔹 PSEUDO
                    if (message.StartsWith("PSEUDO|"))
                    {
                        string pseudo = message.Split('|')[1].Trim();

                        lock (pseudos)
                        {
                            pseudos[clientKey] = string.IsNullOrEmpty(pseudo) ? "Unknown" : pseudo;
                        }

                        Logger.Log($"{clientKey} → pseudo: {pseudos[clientKey]}");
                    }

                    // 🔹 GET NEIGHBOURS
                    else if (message.StartsWith("GET_NEIGHBOURS"))
                    {
                        string response;

                        lock (pseudos)
                        {
                            response = string.Join(",", pseudos.Values);
                        }

                        byte[] data = Encoding.UTF8.GetBytes(response);
                        stream.Write(data, 0, data.Length);
                    }

                    // 🔹 MESSAGE
                    else if (message.StartsWith("MSG|"))
                    {
                        string text = message.Substring(4);

                        Logger.Log($"Message from {GetPseudo(clientKey)}: {text}");
                    }

                    // 🔹 FILE
                    else if (message.StartsWith("FILE|"))
                    {
                        string[] parts = message.Split('|');

                        string fileName = parts[1];
                        long fileSize = long.Parse(parts[2]);

                        FileManager.StartReceiving(fileName, fileSize, stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error: {ex.Message}");
            }
            finally
            {
                stream.Close();
                client.Close();

                clients.TryRemove(clientKey, out _);

                lock (pseudos)
                {
                    pseudos.Remove(clientKey);
                }

                Logger.Log($"{clientKey} disconnected");
            }
        }

        public void sendReceiveSignal(string serverIp, int port, string pseudo)
        {
            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                using (NetworkStream stream = client.GetStream())
                {
                    string message = "PSEUDO|" + pseudo;
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"sendReceiveSignal: {ex.Message}");
            }
        }

        public string GetPseudo(string clientKey)
        {
            if (pseudos.ContainsKey(clientKey))
                return pseudos[clientKey];

            return "Unknown";
        }
    }
}