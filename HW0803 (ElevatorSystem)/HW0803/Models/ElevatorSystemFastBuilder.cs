using HW0803.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Models
{
    public class ElevatorSystemFastBuilder
    {
        public int CarCapacityOfPeople { get; set; }
        public int CarDoorClosingTime { get; set; }
        public int EngineWeightLimit { get; set; }
        public int EngineSpeed { get; set; }
        public int DelayBeforeClosingDoors { get; set; }
        public List<Tuple<int, double>> Floors { get; set; }

        public ElevatorSystem Build()
        {

            var elevatorCar =                   new ElevatorCar(new ElevatorCarConfiguration() { CapacityOfPeople = this.CarCapacityOfPeople, DoorClosingTime = this.CarDoorClosingTime });
            var elevatorEngine =                new ElevatorEngine(new ElevatorEngineConfiguration() { Speed = this.EngineSpeed, WeightLimit = this.EngineWeightLimit });
            var elevatorSystemConfiguration =   new ElevatorSystemConfiguration() { DelayBeforeClosingDoors = this.DelayBeforeClosingDoors };
            List<IFloor> responseFloors =       new List<IFloor>();
            Floors.ForEach(floor => responseFloors.Add(new Floor() { FloorNumber = floor.Item1, HeightRelativeToZero = floor.Item2 }));


            return new ElevatorSystem(elevatorCar, elevatorEngine, responseFloors, elevatorSystemConfiguration);

        }
    }
}
