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

    public enum CurrentStatus : short
    {
        None,
        TakeOff,
        Land
    }
}
