using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0503.Extentions.NumberExtentions
{
    public static class EvenNumberChekerExtentions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
