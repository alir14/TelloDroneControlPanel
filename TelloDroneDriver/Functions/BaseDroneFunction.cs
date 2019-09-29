using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.Functions
{
    internal abstract class BaseDroneFeature
    {
        private Dictionary<string, int> delayCommandsList = new Dictionary<string, int>();

        public Dictionary<string, int> CommandDelayList
        {
            get
            {
                if (delayCommandsList.Count == 0)
                    SetCommandDelayValues();

                return delayCommandsList;
            }
        }

        public DroneResponse InitializeToSendCommnd()
        {
            try
            {
                Console.WriteLine($"Initialize ....");

                var response = ExecuteCommand(ControlCommand.Command);

                Thread.Sleep(CommandDelayList[DroneConstants.COMMAND]);

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

                await Task.Delay(CommandDelayList[DroneConstants.COMMAND]);

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
