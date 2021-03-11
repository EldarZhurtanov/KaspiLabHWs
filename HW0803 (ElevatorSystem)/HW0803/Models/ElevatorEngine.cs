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
    public class ElevatorEngine : IElevatorEngine
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private IElevatorEngineConfiguration engineConfiguration;
        private bool isBreak = false;

        IElevatorEngineConfiguration IElevatorEngine.EngineConfiguration { get => engineConfiguration; set => engineConfiguration = value; }
        bool IElevatorEngine.IsBreak { get => isBreak; set => isBreak = value; }

        public ElevatorEngine(IElevatorEngineConfiguration engineConfiguration)
        {
            this.engineConfiguration = engineConfiguration;
        }
        public void Down(double meters)
        {
            Logger.Info($"Двигатель начинает опускать тросс на {meters} метра/метров");

            Thread.Sleep(Convert.ToInt32(meters / engineConfiguration.Speed) * 1000);

            Logger.Info($"Двигатель закончил опускать тросс");
        }

        public void Up(double meters)
        {
            Logger.Info($"Двигатель начинает поднимать тросс на {meters} метра/метров");

            Thread.Sleep(Convert.ToInt32(meters / engineConfiguration.Speed) * 1000);

            Logger.Info($"Двигатель закончил поднимать тросс");
        }

        public void Move(double meters)
        {
            if (meters < 0)
                Down(Math.Abs(meters));
            else
                Up(meters);
        }
    }
}
