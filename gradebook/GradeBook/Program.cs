using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        // statis is only available for the type so not in instance of type
        static void Main(string[] args)
        {

            var book = new Book("Colin's Grade Book");
            var done = false;
            var input = "";
            var grade = 0.0;
            // arrange
            while (!done)
            {
                Console.WriteLine("Enter a grade od 'q' to quit");
                input = Console.ReadLine();
                if (input == "Q")
                {
                    break;
                }
                grade = double.Parse(input);
                book.AddGrade(grade);
            } while (input != "Q");

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.letter}");

        }
    }
}
