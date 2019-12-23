using System;
using System.Threading;
using System.Threading.Tasks;
using TelloDroneDriver.Command;
using TelloDroneDriver.Manager;
using TelloDroneDriver.Model;

namespace TelloDroneDriver.ServiceLayer
{
    internal class DroneMovementFeature : BaseDroneFeature
    {
        public DroneResponse MoveUp(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Z))
                {
                    var command = ControlCommand.Up(coordinate.Z);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.UP]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public DroneResponse MoveDown(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Z))
                {
                    var command = ControlCommand.Down(coordinate.Z);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.DOWN]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public DroneResponse MoveLeft(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.X))
                {
                    var command = ControlCommand.Left(coordinate.X);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.LEFT]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public DroneResponse MoveRight(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.X))
                {
                    var command = ControlCommand.Right(coordinate.X);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.RIGHT]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public DroneResponse MoveForward(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Y))
                {
                    var command = ControlCommand.Forward(coordinate.Y);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.FORWARD]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public DroneResponse MoveBackward(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Y))
                {
                    var command = ControlCommand.Back(coordinate.Y);

                    var response = MoveDrone(command);

                    Thread.Sleep(base.CommandDelayList[DroneConstants.BACK]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveUpAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Z))
                {
                    var command = ControlCommand.Up(coordinate.Z);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.UP]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveDownAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Z))
                {
                    var command = ControlCommand.Down(coordinate.Z);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.DOWN]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveLeftAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.X))
                {
                    var command = ControlCommand.Left(coordinate.X);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.LEFT]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveRightAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.X))
                {
                    var command = ControlCommand.Right(coordinate.X);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.RIGHT]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveForwardAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Y))
                {
                    var command = ControlCommand.Forward(coordinate.Y);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.FORWARD]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        public async Task<DroneResponse> MoveBackwardAsync(Coordinate coordinate)
        {
            try
            {
                if (ValidateMovementRange(coordinate.Y))
                {
                    var command = ControlCommand.Back(coordinate.Y);

                    var response = await MoveDroneAsync(command);

                    await Task.Delay(base.CommandDelayList[DroneConstants.BACK]);

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return DroneResponse.FAIL;
        }

        private bool ValidateMovementRange(int value)
        {

            if (value > 20 && value < 500)
                return true;
            else
            {
                Console.WriteLine($"value is out of range {value}");

                return false;
            }
        }

        private DroneResponse MoveDrone(string command)
        {
            Console.WriteLine($" Connection: {ControlManager.Instance.IsConnected} & Status: {ControlManager.Instance.FlightStatus}");

            if (ControlManager.Instance.IsConnected &&
                ControlManager.Instance.FlightStatus == CurrentStatus.TakeOff)
            {
                var response = ExecuteCommand(command);

                Console.WriteLine(response);

                return response;
            }

            return DroneResponse.FAIL;
        }

        private async Task<DroneResponse> MoveDroneAsync(string command)
        {
            Console.WriteLine($" Connection: {ControlManager.Instance.IsConnected} & Status: {ControlManager.Instance.FlightStatus}");

            if (ControlManager.Instance.IsConnected &&
                ControlManager.Instance.FlightStatus == CurrentStatus.TakeOff)
            {
                var response = await ExecuteCommandAsync(command);

                Console.WriteLine(response);

                return response;
            }

            return DroneResponse.FAIL;
        }

    }
}
