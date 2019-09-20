using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelloDroneDriver.Model
{
    public class RCParameter
    {
        /// <summary>
        /// left/right (-100~100)
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// forward/backward (-100~100)
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// up/down (-100~100)
        /// </summary>
        public int C { get; set; }

        /// <summary>
        /// yaw (-100~100)
        /// </summary>
        public int D { get; set; }

    }
}
