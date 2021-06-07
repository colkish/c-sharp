using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new double[] { 1, 2, 3, 4, 5, 6 };
            var result = SampleAverage(numbers);
            Console.WriteLine(result);
        }

        private static double SampleAverage(double[] numbers) //no no can't use generics here as we are using  maths equations best solution here is overloaded methods, can't use a constraint to help here
        {
            var count = 0;
            var sum = 0.0;
            for (int i = 0; i < numbers.Length; i+=2)
            {
                sum += numbers[i];
                count += 1;
            }
            return sum / count;
        }
    }
}
