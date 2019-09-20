using System;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;

namespace TelloDroneDriver.Functions
{
    public class DroneMovementFeature : BaseDroneFeature
    {
        public void MoveUp(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Up(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MoveDown(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Down(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MoveLeft(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Left(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MoveRight(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Right(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MoveForward(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Forward(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void MoveBackward(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Back(x);

                    MoveDrone(command);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool ValidateMovementRange(int x)
        {
            if (x > 20 && x < 500)
                return true;
            else
            {
                Console.WriteLine($"value is out of range {x}");

                return false;
            }
        }

        private void MoveDrone(string command)
        {
            Console.WriteLine($" Connection: {ControlManager.Instance.IsConnected} & Status: {ControlManager.Instance.FlightStatus}");

            if (ControlManager.Instance.IsConnected &&
                ControlManager.Instance.FlightStatus == CurrentStatus.TakeOff)
            {
                var response = ExecuteCommand(command);
            }
        }

    }
}
