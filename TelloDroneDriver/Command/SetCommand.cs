using TelloDroneDriver.Model;

namespace TelloDroneDriver.Command
{
    public static class SetCommand
    {
        public static string SetSpeed(int x)
        {
            return $"speed {x}";
        }

        public static string SetRCControl(RCParameter parameter)
        {
            return $"rc {parameter.A} {parameter.B} {parameter.C} {parameter.D}";
        }

        public static string SetWifiPassword(string password)
        {
            return $"wifi ssid {password}";
        }
    }
}
