using System;
using System.Threading.Tasks;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.Functions
{
    internal class DroneConnection : BaseDroneFeature, IDisposable
    {
        public DroneResponse ConnectWithCommand()
        {
            try
            {
                if (ControlManager.Instance.DroneUdpClient == null)
                    return DroneResponse.FAIL;

                Console.WriteLine($"connecting ....");

                ControlManager.Instance.DroneUdpClient.Connect(ControlManager.Instance.DroneEndPoint);

                Console.WriteLine($"connected: ttl: {ControlManager.Instance.DroneUdpClient.Ttl}");

                var initResponse = InitializeToSendCommnd();

                if (initResponse == DroneResponse.OK)
                    ControlManager.Instance.IsConnected = true;
                else
                    ControlManager.Instance.IsConnected = false;

                return initResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }
        }

        public async Task<DroneResponse> ConnectWithCommandAsync()
        {
            try
            {
                if (ControlManager.Instance.DroneUdpClient == null)
                    return DroneResponse.FAIL;

                Console.WriteLine($"connecting ....");

                ControlManager.Instance.DroneUdpClient.Connect(ControlManager.Instance.DroneEndPoint);

                Console.WriteLine($"connected: ttl: {ControlManager.Instance.DroneUdpClient.Ttl}");

                var initResponse = await InitializeToSendCommndAsync();

                if (initResponse == DroneResponse.OK)
                    ControlManager.Instance.IsConnected = true;
                else
                    ControlManager.Instance.IsConnected = false;

                return initResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }
        }

        public DroneResponse Connect()
        {
            try
            {
                if (ControlManager.Instance.DroneUdpClient == null)
                    return DroneResponse.FAIL;

                Console.WriteLine($"connecting ....");

                ControlManager.Instance.DroneUdpClient.Connect(ControlManager.Instance.DroneEndPoint);

                Console.WriteLine($"connected: ttl: {ControlManager.Instance.DroneUdpClient.Ttl}");

                ControlManager.Instance.IsConnected = true;

                return DroneResponse.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }
        }

        public void Disconnect()
        {
            Console.WriteLine($"disconnecting ....");

            ControlManager.Instance.IsConnected = false;

            ControlManager.Instance.DroneUdpClient?.Close();

            Console.WriteLine($"disconnected successfully ....");

        }

        public void Dispose()
        {
            Console.WriteLine($"disposing ....");

            ControlManager.Instance.IsConnected = false;

            ControlManager.Instance.DroneUdpClient?.Dispose();

            Console.WriteLine($"connection is disposed....");
        }
    }
}
