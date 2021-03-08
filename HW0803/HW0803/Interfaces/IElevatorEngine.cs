using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0803.Interfaces
{
    public interface IElevatorEngine
    {
        IElevatorEngineConfiguration Configuration { get; set; }

        void Up(double meters);
        void Down(double meters);
    }
}
