using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace LocalShare
{
    internal class Network
    {
        public static string CurrentIp { get; private set; } = "Not Connected";
        public static event Action<string> IpChanged;

        static Network()
        {
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(OnNetworkChange);
            UpdateIp();
        }

        private static void OnNetworkChange(object sender, EventArgs e)
        {
            UpdateIp();
            Console.WriteLine($"[Network Update] Nouvelle IP: {CurrentIp}");
            IpChanged?.Invoke(CurrentIp);
        }

        public static void UpdateIp()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    ni.OperationalStatus == OperationalStatus.Up)
                {
                    var ipProps = ni.GetIPProperties();
                    foreach (var addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            CurrentIp = addr.Address.ToString();
                            return;
                        }
                    }
                }
            }
            CurrentIp = "Not Connected";
        }

        public static bool IsConnected()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    ni.OperationalStatus == OperationalStatus.Up)
                {
                    return true;
                }
            }
            return false;
        }

        public static string[] getNeighboursList()
        {
            return LanDiscovery.GetNeighbours();
        }
    }
}