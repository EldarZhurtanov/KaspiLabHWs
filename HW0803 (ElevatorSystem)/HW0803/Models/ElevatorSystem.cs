using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using HW0803.Interfaces;
using NLog;

namespace HW0803.Models
{
    public class ElevatorSystem : IElevatorSystem
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IElevatorCar elevatorCar;
        private readonly IElevatorEngine elevatorEngine;
        private readonly List<IFloor> floors;
        private readonly IElevatorSystemConfiguration systemConfiguration;
        private readonly Queue<IFloor> requestedFloors = new Queue<IFloor>();
        private Timer closingDoorsThrough;

        public int СurrentFloor { get; private set; } = 1;
        public bool IsWait { get; private set; } = false;
        public bool IsInMove { get; private set; } = false;
        public bool DoorIsOpen { get; private set; } = false;


        public ElevatorSystem(IElevatorCar elevatorCar, IElevatorEngine elevatorEngine, IEnumerable<IFloor> floors, IElevatorSystemConfiguration systemConfiguration)
        {
            this.elevatorCar = elevatorCar ?? throw new ArgumentNullException(nameof(elevatorCar));
            this.elevatorEngine = elevatorEngine ?? throw new ArgumentNullException(nameof(elevatorEngine));
            this.systemConfiguration = systemConfiguration ?? throw new ArgumentNullException(nameof(systemConfiguration));
            this.floors = (floors ?? throw new ArgumentNullException(nameof(floors))).ToList();

            if (floors.Count() < 1)
                throw new Exception("Bad Floors Configuration");

            this.floors.Sort();

            var previusFloor = this.floors[0];

            for (int i = 1; i < floors.Count(); i++)
                if (previusFloor.FloorNumber > this.floors[i].FloorNumber || previusFloor.HeightRelativeToZero > this.floors[i].HeightRelativeToZero)
                    throw new Exception("Bad Floors Configuration");
                else
                    previusFloor = this.floors[i];
        }


        public ElevatorSystemCodes Call(int floor)
        {
            Logger.Info($"Нажата кнопка вызова на {floor} этаже");
            if (floor > floors.Count() || floor <= 0)
            {
                Logger.Error("Неизвестный этаж");
                return ElevatorSystemCodes.MissingFloor;
            }

            if (!IsInMove && !IsWait)
            {
                if (СurrentFloor == floor)
                {
                    Logger.Info("Лифт уже на этаже");
                    OpenTheDoors();
                    return ElevatorSystemCodes.Ok;
                }
                else
                    GoToTheFloor(TransportedGoods.Empty, floor);
            }
            else
            {
                Logger.Info($"{floor} этаж был добавлен в очередь");
                requestedFloors.Enqueue(floors[floor - 1]);
            }

            return ElevatorSystemCodes.Ok;
        }

        public ElevatorSystemCodes GoToTheFloor(ITransportedGoods transportedGoods, int floor)
        {
            if (IsInMove)
            {
                Logger.Error("Лифт уже в движении");
                return ElevatorSystemCodes.Busy;
            }

            if (elevatorCar.CarConfiguration.CapacityOfPeople < transportedGoods.CountOfPeople)
            {
                Logger.Error("Превышено кол-во людей в кабине");
                return ElevatorSystemCodes.СapacityExceeded;
            }

            if (elevatorEngine.EngineConfiguration.WeightLimit < transportedGoods.TotalWeight)
            {
                Logger.Error("Превышен максимально допустимый вес");
                return ElevatorSystemCodes.Overweight;
            }

            IsWait = false;
            IsInMove = true;

            СloseTheDoors();

            Logger.Info($"Лифт сделует с {СurrentFloor} на {floor} этаж ({transportedGoods.CountOfPeople} человек/человека общим весом {transportedGoods.TotalWeight}кг)");

            double CurrentHeight = floors[СurrentFloor - 1].HeightRelativeToZero;
            double RequiredHeight = floors[floor - 1].HeightRelativeToZero;

            elevatorEngine.Move(RequiredHeight - CurrentHeight);

            Logger.Info($"Лифт прибыл на {floor} этаж");

            СurrentFloor = floor;
            IsWait = true;
            IsInMove = false;
            OpenTheDoors();

            closingDoorsThrough = new Timer(systemConfiguration.DelayBeforeClosingDoors);
            closingDoorsThrough.Elapsed += GoToRequestIfStand;
            closingDoorsThrough.Start();

            return ElevatorSystemCodes.Ok;
        }

        private ElevatorSystemCodes OpenTheDoors()
        {
            if (IsInMove)
            {
                Logger.Error("Лифт в движении. Открытие дверей не возможно");
                return ElevatorSystemCodes.Busy;
            }
            if(DoorIsOpen)
            {
                Logger.Error("Двери уже открыты");
                return ElevatorSystemCodes.Ok;
            }

            elevatorCar.OpenDoor();
            DoorIsOpen = true;

            return ElevatorSystemCodes.Ok;
        }

        private ElevatorSystemCodes СloseTheDoors()
        {
            elevatorCar.CloseDoor();
            DoorIsOpen = false;

            return ElevatorSystemCodes.Ok;
        }
        private void GoToRequestIfStand(object sender, ElapsedEventArgs e)
        {
            if (IsWait && !IsInMove)
            {
                if(requestedFloors.Count == 0)
                    IsWait = false;
                else
                {
                    IFloor requestedFloor = requestedFloors.Dequeue();

                    Logger.Info($"Лифт отправляется на вызов из очереди ({requestedFloor.FloorNumber} этаж)") ;

                    int requestedFloorNumber = floors.FindIndex(a => a.HeightRelativeToZero == requestedFloor.HeightRelativeToZero) + 1;

                    GoToTheFloor(TransportedGoods.Empty, requestedFloorNumber);
                }
            }
            else
                (sender as Timer).Dispose();
        }
    }
}
