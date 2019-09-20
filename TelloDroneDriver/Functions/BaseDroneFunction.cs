using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.Functions
{
    public abstract class BaseDroneFeature
    {
        public DroneResponse InitializeToSendCommnd()
        {
            try
            {
                Console.WriteLine($"Initialize ....");

                var response = ExecuteCommand(ControlCommand.Command);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }

        }

        public DroneResponse EmergencyStop()
        {
            try
            {
                Console.WriteLine($"Stop all acrion: EmergencyStop ....");

                var response = ExecuteCommand(ControlCommand.Emergency);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }
        }

        public async Task<DroneResponse> InitializeToSendCommndAsync()
        {
            try
            {
                Console.WriteLine($"Initialize ....");

                var response = await ExecuteCommandAsync(ControlCommand.Command);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }

        }

        public async Task<DroneResponse> EmergencyStopAsync()
        {
            try
            {
                Console.WriteLine($"Stop all acrion: EmergencyStop ....");

                var response = await ExecuteCommandAsync(ControlCommand.Emergency);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;
            }
        }


        protected DroneResponse ExecuteCommand(string command)
        {
            try
            {
                Console.WriteLine($"execute command: {command}");

                var commandText = Encoding.ASCII.GetBytes(command);

                ControlManager.Instance.DroneUdpClient.Send(commandText, commandText.Length);

                //ControlManager.Instance.DroneUdpClient.Client.ReceiveTimeout = 5000;

                var _recieverEndpoint = new IPEndPoint(IPAddress.Any, 0);

                var responseMessageBytes = ControlManager.Instance.DroneUdpClient.Receive(ref _recieverEndpoint);

                var droneResponse = Encoding.ASCII.GetString(responseMessageBytes);

                Console.WriteLine($"drone response: {droneResponse}");

                if (!string.IsNullOrEmpty(droneResponse))
                {
                    return (droneResponse == DroneResponse.OK.ToString()) ? DroneResponse.OK : DroneResponse.FAIL;
                }
                else
                    return DroneResponse.FAIL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return DroneResponse.FAIL;

            }
        }

        protected async Task<DroneResponse> ExecuteCommandAsync(string command)
        {
            try
            {
                Console.WriteLine($"execute command: {command}");

                var commandText = Encoding.ASCII.GetBytes(command);

                await ControlManager.Instance.DroneUdpClient.SendAsync(commandText, commandText.Length);

                //ControlManager.Instance.DroneUdpClient.Client.ReceiveTimeout = 5000;

                var responseMessageBytes = await ControlManager.Instance.DroneUdpClient.ReceiveAsync();

                var droneResponse = Encoding.ASCII.GetString(responseMessageBytes.Buffer);

                if (!string.IsNullOrEmpty(droneResponse))
                {
                    return (droneResponse == DroneResponse.OK.ToString()) ? DroneResponse.OK : DroneResponse.FAIL;
                }

                return DroneResponse.FAIL;
            }
            catch
            {
                throw;
            }
        }
    }
}
