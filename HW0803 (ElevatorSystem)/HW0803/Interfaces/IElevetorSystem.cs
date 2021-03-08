using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IElevetorSystem
    {
        IBuildingConfiguration BuildingConfiguration { get; set; }
        IElevatorCarConfiguration ElevatorCarConfiguration { get; set; }
        IElevatorEngine ElevatorEngine { get; set; }

        ElevatorSystemCodes СloseTheDoors();
        ElevatorSystemCodes OpenTheDoors();
        ElevatorSystemCodes CallTheLift();
        ElevatorSystemCodes GoToTheFloor();


    }
}
