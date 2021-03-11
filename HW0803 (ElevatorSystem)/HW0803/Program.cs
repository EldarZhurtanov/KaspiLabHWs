using HW0803.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0803
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            ConfigurateNLog.Confugurate();

            var builder = new ElevatorSystemFastBuilder();

            builder.CarCapacityOfPeople = 4;
            builder.CarDoorClosingTime = 2000;
            builder.DelayBeforeClosingDoors = 5000;
            builder.EngineSpeed = 3;
            builder.EngineWeightLimit = 300;
            builder.Floors = new List<Tuple<int, double>>() 
            { 
                new Tuple<int, double>(1, 1), 
                new Tuple<int, double>(2, 5),
                new Tuple<int, double>(3, 6),
                new Tuple<int, double>(4, 10),
                new Tuple<int, double>(5, 10.5),
                new Tuple<int, double>(6, 14),

            };

            var elevatorSystem = builder.Build();

            _ = elevatorSystem.Call(1);
            Thread.Sleep(1000);
            _ = elevatorSystem.GoToTheFloor(new TransportedGoods() {CountOfPeople = 1, TotalWeight = 100 }, 4);
            Thread.Sleep(3000);
            _ = elevatorSystem.GoToTheFloor(new TransportedGoods() { CountOfPeople = 3, TotalWeight = 270 }, 3);
            Thread.Sleep(3000);
            _ = elevatorSystem.Call(1);
            Thread.Sleep(3000);
            _ = elevatorSystem.Call(2);
            Thread.Sleep(8000);
            _ = elevatorSystem.GoToTheFloor(new TransportedGoods() { CountOfPeople = 8, TotalWeight = 250 }, 5);
            _ = elevatorSystem.GoToTheFloor(new TransportedGoods() { CountOfPeople = 2, TotalWeight = 400 }, 5);
            _ = elevatorSystem.GoToTheFloor(new TransportedGoods() { CountOfPeople = 2, TotalWeight = 100 }, 1);

            Console.ReadKey();
        }
    }
}
