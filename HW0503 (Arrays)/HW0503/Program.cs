using HW0503.Extentions.NumberExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0503
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 13, 65, 63, 26, 93, 6, 95, 35, 96, 71 };

            var primeNumbers = numbers.FindAll(number => number.IsPrime());
            var evenNumbers = numbers.FindAll(number => number.IsEven());
            var sum = numbers.Sum();

            Console.Write("Исходный масиив: ");
            numbers.ForEach(number => Console.Write(number + "; "));

            Console.Write("\n\nПростые числа: ");
            primeNumbers.ForEach(number => Console.Write(number + "; "));

            Console.Write("\nЧётные числа: ");
            evenNumbers.ForEach(number => Console.Write(number + "; "));

            Console.Write($"\n\nСумма всех чисел: {sum}");

            Console.ReadKey();
        }
    }
}
