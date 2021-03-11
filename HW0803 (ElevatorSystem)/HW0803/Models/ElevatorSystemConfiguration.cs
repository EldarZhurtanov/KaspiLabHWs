using HW0803.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Models
{
    class ElevatorSystemConfiguration : IElevatorSystemConfiguration
    {
        private int delayBeforeClosingDoors;

        public int DelayBeforeClosingDoors { get => delayBeforeClosingDoors; set => delayBeforeClosingDoors = value; }
    }
}
