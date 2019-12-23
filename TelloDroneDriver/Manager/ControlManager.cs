using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using TelloDroneDriver.Core;
using TelloDroneDriver.ServiceLayer;

namespace TelloDroneDriver.Manager
{
    public class ControlManager
    {
        private static volatile ControlManager _instance = null;
        private static object lockObject = new object();
        private readonly IUdpClientWrapper _udpClientWrapper;

        public ControlManager()
        {
            _udpClientWrapper = new UdpClientWrapper();
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

        public CurrentStatus FlightStatus { get; set; }

        public bool IsConnected { get; set; }

        public DroneResponse Connect()
        {
            return _udpClientWrapper.Connect();
        }

        public int Send(byte[] command)
        {
            return _udpClientWrapper.Send(command);
        }

        public async Task<int> SendAsync(byte[] command)
        {
            return await _udpClientWrapper.SendAsync(command);
        }

        public byte[] Receive()
        {
            return _udpClientWrapper.Rceive();
        }

        public DroneResponse EmergencyStop()
        {
            DroneMovementFeature _movement = new DroneMovementFeature();
            return _movement.EmergencyStop();
        }
    }
}
