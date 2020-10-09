using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {

        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }
        
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {

            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach (double number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;

            Console.WriteLine($"The highest grade is {highGrade:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
            Console.WriteLine($"The avarage grade is {result:N1}");

        }

        //Properties usually private
        private List<double> grades;
        private string name;

    }

}