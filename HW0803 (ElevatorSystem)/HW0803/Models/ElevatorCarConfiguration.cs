using HW0803.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Models
{
    class ElevatorCarConfiguration : IElevatorCarConfiguration
    {
        private int capacityOfPeople;
        private int doorClosingTime;
        public int CapacityOfPeople { get => capacityOfPeople; set => capacityOfPeople = value; }
        public int DoorClosingTime { get => doorClosingTime; set => doorClosingTime = value; }
    }
}
