using System;
using System.Threading;
using System.Threading.Tasks;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.ServiceLayer
{
    internal class DronTaxiFeature : BaseDroneFeature
    {
        public DroneResponse TakeOff()
        {
            var response = DroneAction(ControlCommand.TakeOff);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.TakeOff;

            Thread.Sleep(base.CommandDelayList[DroneConstants.TAKEOFF]);

            return response;
        }

        public DroneResponse AutoLand()
        {
            var response = DroneAction(ControlCommand.Land);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.Land;

            Thread.Sleep(base.CommandDelayList[DroneConstants.LAND]);

            return response;
        }

        public async Task<DroneResponse> TakeOffAsync()
        {
            var response = await DroneActionAsync(ControlCommand.TakeOff);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.TakeOff;

            await Task.Delay(base.CommandDelayList[DroneConstants.TAKEOFF]);

            return response;
        }

        public async Task<DroneResponse> AutoLandAsync()
        {
            var response = await DroneActionAsync(ControlCommand.Land);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.Land;

            await Task.Delay(base.CommandDelayList[DroneConstants.LAND]);

            return response;
        }

        private DroneResponse DroneAction(string command)
        {
            Console.WriteLine($"Drone status: FlightStatus: {ControlManager.Instance.FlightStatus}");

            return ExecuteCommand(command);
        }

        private async Task<DroneResponse> DroneActionAsync(string command)
        {
            Console.WriteLine($"Drone status: FlightStatus: {ControlManager.Instance.FlightStatus}");

            return await ExecuteCommandAsync(command);
        }
    }
}
