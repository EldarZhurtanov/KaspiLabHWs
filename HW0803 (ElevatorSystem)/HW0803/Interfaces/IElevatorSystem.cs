using HW0803.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IElevatorSystem
    {
        ElevatorSystemCodes Call(int floor);
        ElevatorSystemCodes GoToTheFloor(ITransportedGoods transportedGoods, int floor);
    }
}
