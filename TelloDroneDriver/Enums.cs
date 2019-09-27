using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelloDroneDriver
{
    public enum DroneResponse : short
    {
        OK,
        FAIL
    }

    public enum CommandMode : short
    {
        CommandMode,
        Control,
        Read,
        Set
    }

    public enum DroneCommandEnum : short
    {
        COMMAND,
        TAKEOFF,
        LAND,
        UP,
        DOWN,
        LEFT,
        RIGHT,
        GO,
        FORWARD,
        BACK,
        CW,
        CCW,
        FLIP,
        SPEED,
        BATTERY_STATE,
        SPEED_STATE,
        TIME_STATE
    }

    public enum CurrentStatus : short
    {
        None,
        TakeOff,
        Land
    }

    public enum CommandStatuEnum
    {
        None,
        Pending,
        Done,
        Ignored,
        Error
    }
}
