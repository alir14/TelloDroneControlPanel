using System;

namespace TelloDroneDriver.Model
{
    public class CommandModel
    {
        public int Id { get; set; }

        public string Command { get; set; }

        public CommandStatuEnum CommandStatus { get; set; }

        public TimeSpan Time { get; set; }

        public CommandMode CommandType { get; set; }
    }
}
