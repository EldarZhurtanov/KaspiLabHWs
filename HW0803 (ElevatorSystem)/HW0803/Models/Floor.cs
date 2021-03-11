using HW0803.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Models
{
    public class Floor : IFloor, IComparable
    {
        private double heightRelativeToZero;
        private int floorNumber;

        public double HeightRelativeToZero { get => heightRelativeToZero; set => heightRelativeToZero = value; }
        public int FloorNumber { get => floorNumber; set => floorNumber = value; }

        public int CompareTo(object obj)
        {
            var comparableFloor = obj as Floor;
            if (this.floorNumber > comparableFloor.floorNumber)
                return 1;
            else if (this.floorNumber > comparableFloor.floorNumber)
                return -1;
            else
                return 0;
        }
    }
}
