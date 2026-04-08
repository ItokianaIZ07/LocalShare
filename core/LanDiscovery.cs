using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using LocalShare.Core;

namespace LocalShare
{
    public class LanDiscovery
    {
        private const int PORT = 8888;

        private UdpClient udpClient;
        private Thread listenThread;

        public static ConcurrentDictionary<string, string> Neighbours
            = new ConcurrentDictionary<string, string>();

        private string myPseudo;

        public event Action<NetworkUser> OnUserDiscovered;

        public LanDiscovery(string pseudo)
        {
            myPseudo = pseudo;
        }

        public void Start()
        {
            udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, PORT));
            udpClient.EnableBroadcast = true;

            listenThread = new Thread(Listen);
            listenThread.IsBackground = true;
            listenThread.Start();

            new Thread(() =>
            {
                while (true)
                {
                    BroadcastPresence();
                    Thread.Sleep(2000);
                }
            })
            { IsBackground = true }.Start();
        }

        private void BroadcastPresence()
        {
            try
            {
                using (UdpClient sender = new UdpClient())
                {
                    sender.EnableBroadcast = true;

                    string message = $"DISCOVER|{myPseudo}";
                    byte[] data = Encoding.UTF8.GetBytes(message);

                    sender.Send(data, data.Length,
                        new IPEndPoint(IPAddress.Broadcast, PORT));
                }
            }
            catch { }
        }

        private void Listen()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, PORT);

            while (true)
            {
                try
                {
                    byte[] data = udpClient.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);

                    if (message.StartsWith("DISCOVER|"))
                    {
                        string pseudo = message.Split('|')[1];
                        string ip = remoteEP.Address.ToString();

                        if (pseudo != myPseudo)
                        {
                            bool isNew = !Neighbours.ContainsKey(ip);

                            Neighbours[ip] = pseudo;

                            if (isNew)
                            {
                                OnUserDiscovered?.Invoke(new NetworkUser
                                {
                                    Pseudo = pseudo,
                                    IP = ip
                                });
                                Logger.Log($"Reçu: {message} de {remoteEP.Address}");
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public static string[] GetNeighbours()
        {
            return Neighbours.Values.ToArray();
        }

        public static Dictionary<string, string> GetNeighboursWithIp()
        {
            return new Dictionary<string, string>(Neighbours);
        }
    }
}