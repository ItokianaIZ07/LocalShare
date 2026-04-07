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

        public ConnectionManager(int port)
        {
            Port = port;
            clients = new ConcurrentDictionary<string, TcpClient>();
        }

        public void StartServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, Port);
                server.Start();
                Logger.Log($"Server started on port {Port}");

                new Thread(AcceptClients).Start();
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
                foreach (var client in clients.Values)
                {
                    client.Close();
                }
                server.Stop();
                Logger.Log("Server stopped");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to stop server: {ex.Message}");
            }
        }

        private void AcceptClients()
        {
            // À implémenter : boucle accept TcpClient
        }

        private void HandleClient(TcpClient client)
        {
            // À implémenter : boucle de réception pour ce client
        }

        private void DisconnectClient(string clientKey)
        {
            // À implémenter : retirer client + fermer socket
        }

        //  Communication
        public void SendMessage(string clientKey, byte[] data)
        {
            // À implémenter : envoyer données à un client précis
        }

        public void Broadcast(byte[] data)
        {
            // À implémenter : envoyer à tous les clients
        }

        //  Utilitaires
        public string[] GetConnectedClients()
        {
            return clients.Keys.ToArray();
        }
    }
}