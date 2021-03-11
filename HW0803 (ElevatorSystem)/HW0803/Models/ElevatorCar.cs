using HW0803.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0803.Models
{
    class ElevatorCar : IElevatorCar
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public IElevatorCarConfiguration CarConfiguration { get; set; }

        public ElevatorCar(IElevatorCarConfiguration carConfiguration)
        {
            CarConfiguration = carConfiguration;
        }

        public void CloseDoor()
        {
            Logger.Info("Кабина закрывает двери");
            Thread.Sleep(CarConfiguration.DoorClosingTime);
        }

        public void OpenDoor()
        {
            Logger.Info("Кабина открывает двери");
            Thread.Sleep(CarConfiguration.DoorClosingTime);
        }
    }
}
