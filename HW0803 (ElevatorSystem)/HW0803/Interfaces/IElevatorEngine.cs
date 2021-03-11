using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IElevatorEngine
    {
        IElevatorEngineConfiguration EngineConfiguration { get; set; }
        bool IsBreak { get; set; }
        void Move(double meters);
    }
}
