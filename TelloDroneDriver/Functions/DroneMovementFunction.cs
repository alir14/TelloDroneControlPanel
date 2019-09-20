using System;
using System.Threading;
using System.Threading.Tasks;
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.UP]);
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.DOWN]);
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.LEFT]);
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.RIGHT]);
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.FORWARD]);
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

                    Thread.Sleep(ControlManager.Instance.CommandDelayList[DroneConstants.BACK]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task MoveUpAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Up(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.UP]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task MoveDownAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Down(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.DOWN]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task MoveLeftAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Left(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.LEFT]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task MoveRightAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Right(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.RIGHT]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task MoveForwardAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Forward(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.FORWARD]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task MoveBackwardAsync(int x)
        {
            try
            {
                if (ValidateMovementRange(x))
                {
                    var command = ControlCommand.Back(x);

                    await MoveDroneAsync(command);

                    await Task.Delay(ControlManager.Instance.CommandDelayList[DroneConstants.BACK]);

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

                Console.WriteLine(response);
            }
        }

        private async Task MoveDroneAsync(string command)
        {
            Console.WriteLine($" Connection: {ControlManager.Instance.IsConnected} & Status: {ControlManager.Instance.FlightStatus}");

            if (ControlManager.Instance.IsConnected &&
                ControlManager.Instance.FlightStatus == CurrentStatus.TakeOff)
            {
                var response = await ExecuteCommandAsync(command);

                Console.WriteLine(response);
            }
        }

    }
}
