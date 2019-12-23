using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TelloDroneDriver.Core
{
    public interface IUdpClientWrapper
    {
        DroneResponse Connect();
        int Send(byte[] command);
        Task<int> SendAsync(byte[] command);
        byte[] Rceive();
        void Close();
    }

    public class UdpClientWrapper: IUdpClientWrapper, IDisposable
    {
        private const string _ipAddress = "192.168.10.1";
        private const int _port = 8889;
        private readonly UdpClient _droneClient;
        private readonly IPEndPoint _droneEndPoint;
        private readonly IPAddress _droneIPAddress;

        public UdpClient DroneUdpClient => _droneClient;
        public IPEndPoint DroneEndPoint => _droneEndPoint;

        public UdpClientWrapper()
        {
            _droneIPAddress = IPAddress.Parse(_ipAddress);

            _droneClient = new UdpClient();
            _droneEndPoint = new IPEndPoint(_droneIPAddress, _port);
        }

        public void Close()
        {
            _droneClient?.Close();
        }

        public DroneResponse Connect()
        {
            if (_droneClient == null)
                return DroneResponse.FAIL;

            Console.WriteLine($"connecting ....");

            _droneClient.Connect(_droneEndPoint);

            Console.WriteLine($"connected: ttl: {_droneClient.Ttl}");

            return DroneResponse.OK;
        }

        public byte[] Rceive()
        {
            var _recieverEndpoint = new IPEndPoint(IPAddress.Any, 0);

            return _droneClient.Receive(ref _recieverEndpoint);
        }

        public int Send(byte[] command)
        {
            return _droneClient.Send(command, command.Length);
        }

        public async Task<int> SendAsync(byte[] command)
        {
            return await _droneClient.SendAsync(command, command.Length);
        }

        public void Dispose()
        {
            _droneClient?.Dispose();
        }
    }
}
