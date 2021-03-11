using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW0803.Interfaces;
    
namespace HW0803.Models
{
    public struct TransportedGoods : ITransportedGoods
    {
        public int CountOfPeople { get; set; }
        public int TotalWeight { get; set; }

        public static TransportedGoods Empty { get => new TransportedGoods { CountOfPeople = 0, TotalWeight = 0 }; }
    }
}
