using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IElevatorCar
    {
        IElevatorCarConfiguration CarConfiguration { get; set; }
        void OpenDoor();
        void CloseDoor();
    }
}
