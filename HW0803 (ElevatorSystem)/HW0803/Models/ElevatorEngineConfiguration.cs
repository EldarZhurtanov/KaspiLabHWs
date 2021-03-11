using HW0803.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Models
{
    class ElevatorEngineConfiguration : IElevatorEngineConfiguration
    {
        private int weightLimit;
        private int speed;

        public int WeightLimit { get => weightLimit; set => weightLimit = value; }
        public int Speed { get => speed; set => speed = value; }
    }
}
