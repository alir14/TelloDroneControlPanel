using System;
using System.Threading.Tasks;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.ServiceLayer
{
    internal class DroneConnection : BaseDroneFeature
    {
        public DroneResponse ConnectWithCommand()
        {
            try
            {
                ControlManager.Instance.Connect();

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
                ControlManager.Instance.Connect();

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
    }
}
