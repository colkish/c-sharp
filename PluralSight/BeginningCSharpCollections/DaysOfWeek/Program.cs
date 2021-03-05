using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek =
            {
                 "Monday"
                ,"Tuesday"
                ,"Wensday"
                ,"Thursday"
                ,"Friday"
                ,"Saturday"
                ,"Sunday"
            };

            Console.WriteLine("\r\nBEfore:");
            foreach (string day in daysOfTheWeek)
                Console.WriteLine(day);

            daysOfTheWeek[2] = "Wednesday";

            Console.WriteLine("\r\nAfter:");
            foreach (string day in daysOfTheWeek)
                Console.WriteLine(day);

            Console.WriteLine("Which day do you want to display?");
            Console.WriteLine("(Monday = 1 etc.) >");
            int iDay = int.Parse(Console.ReadLine()); //Readline always returns a string, so convert to a int

            string chosenDay = daysOfTheWeek[iDay-1];
            Console.WriteLine($"That day is {chosenDay}"); //$ alays varables in a string


        }
    }
}
