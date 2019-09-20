using TelloDroneDriver.Model;

namespace TelloDroneDriver.Command
{
    public static class ControlCommand
    {
        public const string Command = "command";
        public const string TakeOff = "takeoff";
        public const string Land = "land";
        public const string StreamOn = "streamon";
        public const string StreamOff = "streamoff";
        public const string Emergency = "emergency";

        public static string Up(int x)
        {
            return $"up {x}";
        }

        public static string Down(int x)
        {
            return $"down {x}";
        }

        public static string Left(int x)
        {
            return $"left {x}";
        }

        public static string Right(int x)
        {
            return $"right {x}";
        }

        public static string Forward(int x)
        {
            return $"forward {x}";
        }

        public static string Back(int x)
        {
            return $"back {x}";
        }

        public static string RotateXDegreeClockwise(int x)
        {
            return $"cw {x}";
        }

        public static string RotateXDegreeCounterClockwise(int x)
        {
            return $"ccw {x}";
        }

        public static string Flip(int x)
        {
            return $"flip {x}";
        }

        public static string GoCommand(Coordinate coordinate, int speed)
        {
            return $"go {coordinate.X} {coordinate.Y} {coordinate.Z} {speed}";
        }

        public static string GoCurveCommand(Coordinate coordinate1, Coordinate coordinate2, int speed)
        {
            return $"curve {coordinate1.X} {coordinate1.Y} {coordinate1.Z} {coordinate2.X} {coordinate2.Y} {coordinate2.Z} {speed}";
        }
    }
}
