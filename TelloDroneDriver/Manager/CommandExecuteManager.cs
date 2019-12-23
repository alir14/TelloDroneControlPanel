using System;
using System.Linq;
using System.Threading.Tasks;
using TelloDroneDriver.ServiceLayer;
using TelloDroneDriver.Model;
using System.Threading;

namespace TelloDroneDriver.Manager
{
    public class CommandExecuteManager
    {
        private readonly DroneConnection _baseDroneFeature = new DroneConnection();
        private readonly DronTaxiFeature _taxiFeature = new DronTaxiFeature();
        private readonly DroneMovementFeature _movement = new DroneMovementFeature();

        private static CommandExecuteManager instance = null;
        private static volatile object padLock = new object();

        public DroneResponse Response { get; set; } = DroneResponse.FAIL;

        private CommandExecuteManager() { }

        public static CommandExecuteManager Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (padLock)
                    {
                        if (instance == null)
                        {
                            instance = new CommandExecuteManager();
                        }
                    }
                }
                return instance;
            }
        }

        public void Start(object obj)
        {
            try
            {
                CancellationToken token = (CancellationToken)obj;

                Response = _baseDroneFeature.ConnectWithCommand();

                if(Response == DroneResponse.FAIL)
                {
                    Console.WriteLine("Cannot connect and send command");
                    return;
                }

                while (!token.IsCancellationRequested)
                {
                    //get all pending
                    var pendingJobs = CommandPipeLine.Instance.CommandList.Where(x => x.CommandStatus == CommandStatuEnum.Pending);

                    foreach (var item in pendingJobs)
                    {
                        if(item != null)
                        {
                            // 1) execute it 
                            Response = ExecuteCommandAsync(item).GetAwaiter().GetResult();

                            if (Response == DroneResponse.OK)
                                CommandPipeLine.Instance.DropCommandFromPipeLine(item, CommandStatuEnum.Done);
                            else
                                CommandPipeLine.Instance.DropCommandFromPipeLine(item, CommandStatuEnum.Ignored);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        private async Task<DroneResponse> ExecuteCommandAsync(CommandModel item)
        {
            switch (item.Command)
            {
                case DroneCommandEnum.COMMAND:
                    break;
                case DroneCommandEnum.TAKEOFF:
                    return await _taxiFeature.TakeOffAsync();
                case DroneCommandEnum.LAND:
                    return await _taxiFeature.AutoLandAsync();
                case DroneCommandEnum.UP:
                    return await _movement.MoveUpAsync(item.Coordinate);
                case DroneCommandEnum.DOWN:
                    return await _movement.MoveDownAsync(item.Coordinate);
                case DroneCommandEnum.LEFT:
                    return await _movement.MoveLeftAsync(item.Coordinate);
                case DroneCommandEnum.RIGHT:
                    return await _movement.MoveRightAsync(item.Coordinate);
                case DroneCommandEnum.GO:
                    break;
                case DroneCommandEnum.FORWARD:
                    return await _movement.MoveForwardAsync(item.Coordinate);
                case DroneCommandEnum.BACK:
                    return await _movement.MoveBackwardAsync(item.Coordinate);
                case DroneCommandEnum.CW:
                    break;
                case DroneCommandEnum.CCW:
                    break;
                case DroneCommandEnum.FLIP:
                    break;
                case DroneCommandEnum.SPEED:
                    break;
                case DroneCommandEnum.BATTERY_STATE:
                    break;
                case DroneCommandEnum.SPEED_STATE:
                    break;
                case DroneCommandEnum.TIME_STATE:
                    break;
                default:
                    break;
            }

            return DroneResponse.FAIL;
        }
    }
}
