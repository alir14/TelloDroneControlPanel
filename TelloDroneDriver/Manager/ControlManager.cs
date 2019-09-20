using System.Net;
using System.Net.Sockets;

namespace TelloDroneDriver.Manager
{
    public class ControlManager
    {
        private static volatile ControlManager _instance = null;
        private static object lockObject = new object();
        private const string _ipAddress = "192.168.10.1";
        private const int _port = 8889;

        private readonly IPAddress _droneIPAddress;
        private readonly IPEndPoint _droneEndPoint;
        private readonly UdpClient _droneClient;

        private ControlManager()
        {
            _droneIPAddress = IPAddress.Parse(_ipAddress);
            _droneEndPoint = new IPEndPoint(_droneIPAddress, _port);
            _droneClient = new UdpClient();
        }

        public static ControlManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ControlManager();
                        }
                    }
                }

                return _instance;
            }
        }

        public bool IsConnected { get; set; }

        public UdpClient DroneUdpClient => _droneClient;

        public IPEndPoint DroneEndPoint => _droneEndPoint;

        public CurrentStatus FlightStatus { get; set; }
    }
}
