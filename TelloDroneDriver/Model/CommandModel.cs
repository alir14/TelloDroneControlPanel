using System;

namespace TelloDroneDriver.Model
{
    public class CommandModel
    {
        public int Id { get; set; }

        public DroneCommandEnum Command { get; set; }

        public Coordinate Coordinate { get; set; } = new Coordinate();

        public Coordinate CurveCoordinate { get; set; } = new Coordinate();

        public int SpeedValue { get; set; }

        public CommandStatuEnum CommandStatus { get; set; }

        public TimeSpan Time { get; set; }

        public CommandMode CommandType { get; set; }
    }
}
