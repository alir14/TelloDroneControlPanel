using System.Collections.Generic;
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

        private Dictionary<string, int> delayCommandsList = new Dictionary<string, int>();

        private ControlManager()
        {
            _droneIPAddress = IPAddress.Parse(_ipAddress);
            _droneEndPoint = new IPEndPoint(_droneIPAddress, _port);
            _droneClient = new UdpClient();
            SetCommandDelayValues();

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

        public Dictionary<string, int> CommandDelayList
        {
            get
            {
                return delayCommandsList;
            }
        } 

        private void SetCommandDelayValues()
        {
            delayCommandsList.Add(DroneConstants.COMMAND, 500);
            delayCommandsList.Add(DroneConstants.TAKEOFF, 5000);
            delayCommandsList.Add(DroneConstants.LAND, 5000);
            delayCommandsList.Add(DroneConstants.UP, 7000);
            delayCommandsList.Add(DroneConstants.DOWN, 7000);
            delayCommandsList.Add(DroneConstants.LEFT, 5000);
            delayCommandsList.Add(DroneConstants.RIGHT, 5000);
            delayCommandsList.Add(DroneConstants.GO, 7000);
            delayCommandsList.Add(DroneConstants.FORWARD, 5000);
            delayCommandsList.Add(DroneConstants.BACK, 5000);
            delayCommandsList.Add(DroneConstants.CW, 5000);
            delayCommandsList.Add(DroneConstants.CCW, 5000);
            delayCommandsList.Add(DroneConstants.FLIP, 3000);
            delayCommandsList.Add(DroneConstants.SPEED, 3000);
            delayCommandsList.Add(DroneConstants.BATTERY_STATE, 500);
            delayCommandsList.Add(DroneConstants.SPEED_STATE, 500);
            delayCommandsList.Add(DroneConstants.TIME_STATE, 500);
        }
    }
}
