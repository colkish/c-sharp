using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {

        public void AddLetterGrad(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }
        
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                Console.WriteLine("Invalid Value");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            if (grades.Count > 0)
            { 
                for  (var index = 0; index < grades.Count; index += 1)
                {
                    result.High = Math.Max(grades[index], result.High);
                    result.Low = Math.Min(grades[index], result.Low);
                    result.Average += grades[index];
                }
                result.Average /= grades.Count;

                switch (result.Average)
                {
                    case var d when d > 90.0:
                        result.letter = 'A';
                        break;
                    case var d when d > 80.0:
                        result.letter = 'B';
                        break;
                    case var d when d > 70.0:
                        result.letter = 'C';
                        break;
                    case var d when d > 60.0:
                        result.letter = 'D';
                        break;
                    default:
                        result.letter = 'F';
                        break;
                }

            }
           else
           {
                result.High = 0;
                result.Low = 0;
                result.Average = 0;
           }
            return result;
         }

        //Properties usually private
        private List<double> grades;
        public string Name;

    }

}