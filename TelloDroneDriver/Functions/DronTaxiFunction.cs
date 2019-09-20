using System;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.Functions
{
    public class DronTaxiFeature : BaseDroneFeature
    {
        public void TakeOff()
        {
            var response = DroneAction(ControlCommand.TakeOff);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.TakeOff;
        }

        public void AutoLand()
        {
            var response = DroneAction(ControlCommand.Land);

            if (response == DroneResponse.OK)
                ControlManager.Instance.FlightStatus = CurrentStatus.Land;
        }

        private DroneResponse DroneAction(string command)
        {
            Console.WriteLine($"Drone status: FlightStatus: {ControlManager.Instance.FlightStatus}");

            return ExecuteCommand(command);
        }
    }
}
