using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IFloor
    {
        double HeightRelativeToZero { get; set; }
        int FloorNumber { get; set; }
    }
}
