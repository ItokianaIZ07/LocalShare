using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;

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
            try
            {
                server = new TcpListener(IPAddress.Any, Port);
                server.Start();
                Logger.Log($"Server started on port {Port}");
                Logger.Log("Waiting for clients...");

                Thread acceptThread = new Thread(AcceptClients);
                acceptThread.IsBackground = true;
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to start server: {ex.Message}");
            }
        }

        public void StopServer()
        {
            try
            {
                foreach (var client in clients.Keys)
                {
                    DisconnectClient(client);
                }
                server.Stop();
                Logger.Log("Server stopped");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to stop server: {ex.Message}");
            }
        }

        private string getPseudo(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            byte[] buffer = new byte[4096];
            string message = null;
            while (true)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                byte[] data = new byte[bytesRead];
                Array.Copy(buffer, 0, data, 0, bytesRead);

                message = System.Text.Encoding.UTF8.GetString(data);
                if (message.StartsWith("PSEUDO|"))
                {
                    message = message.Split("|")[1];
                    break;
                }
            }
            return message.Trim() != "" ? message : "Unknown";
        }

        private void AcceptClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
                    clients.TryAdd(clientKey, client);
                    lock (pseudos)
                    {
                        pseudos[clientKey] = getPseudo(client);
                    }
                    Logger.Log($"Client connected: {clientKey} - Pseudo : {pseudos[clientKey]}");

                    new Thread(() => HandleClient(client)) { IsBackground = true }.Start();
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error accepting client: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
            NetworkStream stream = null;

            try
            {
                stream = client.GetStream();
                Logger.Log($"Handling client {clientKey}");

                byte[] buffer = new byte[4096];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        Logger.Log($"Client {clientKey} disconnected.");
                        break;
                    }

                    byte[] data = new byte[bytesRead];
                    Array.Copy(buffer, 0, data, 0, bytesRead);

                    string message = System.Text.Encoding.UTF8.GetString(data);

                    if (message.StartsWith("PSEUDO|"))
                    {
                        string pseudo = message.Split('|')[1].Trim();
                        lock (pseudos)
                        {
                            pseudos[clientKey] = pseudo != "" ? pseudo : "Unknown";
                        }
                        Logger.Log($"Client {clientKey} set pseudo: {pseudos[clientKey]}");
                    }
                    else if (message.StartsWith("MSG|"))
                    {
                        string text = message.Substring(4); // retirer MSG|
                        Logger.Log($"Message from {pseudos.GetValueOrDefault(clientKey, clientKey)}: {text}");
                    }
                    else if (message.StartsWith("FILE|"))
                    {
                        // Format attendu: FILE|nomFichier|taille
                        string[] parts = message.Split('|');
                        if (parts.Length >= 3)
                        {
                            string fileName = parts[1];
                            long fileSize = long.Parse(parts[2]);

                            Logger.Log($"Receiving file '{fileName}' ({fileSize} bytes) from {pseudos.GetValueOrDefault(clientKey, clientKey)}");

                            FileManager.StartReceiving(fileName, fileSize, stream);

                            Logger.Log($"File '{fileName}' received from {pseudos.GetValueOrDefault(clientKey, clientKey)}");
                        }
                        else
                        {
                            Logger.Error("Invalid FILE message format.");
                        }
                    }
                    else
                    {
                        Logger.Log($"Unknown message from {clientKey}: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error with client {clientKey}: {ex.Message}");
            }
            finally
            {
                // Nettoyage
                if (stream != null) stream.Close();
                client.Close();
                clients.TryRemove(clientKey, out _);
                lock (pseudos)
                {
                    if (pseudos.ContainsKey(clientKey))
                        pseudos.Remove(clientKey);
                }
                Logger.Log($"Client {clientKey} removed from ConnectionManager.");
            }
        }

        private void DisconnectClient(string clientKey)
        {
            if (clients.TryRemove(clientKey, out TcpClient client))
            {
                client.Close();

                if (pseudos.ContainsKey(clientKey))
                    pseudos.Remove(clientKey);

                Logger.Log($"Client {clientKey} disconnected");
            }
        }

        public void SendMessage(string clientKey, byte[] data)
        {
            try
            {
                if (clients.ContainsKey(clientKey))
                {
                    TcpClient client = clients[clientKey];
                    NetworkStream stream = client.GetStream();

                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
                else
                {
                    Logger.Error($"Client {clientKey} not found.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"SendMessage error ({clientKey}): {ex.Message}");
            }
        }

        public void Broadcast(byte[] data)
        {
            foreach (var clientKey in clients.Keys)
            {
                SendMessage(clientKey, data);
            }
        }

        // 🔹 Utilitaires
        public string[] GetConnectedClients()
        {
            return clients.Keys.ToArray();
        }

        public string GetPseudo(string clientKey)
        {
            if (pseudos.ContainsKey(clientKey))
                return pseudos[clientKey];

            return "Unknown";
        }
    }
}