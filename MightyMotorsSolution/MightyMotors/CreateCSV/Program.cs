// https://code-maze.com/csharp-writing-csv-file/
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CreateCSV
{
    class Program
    {
        static void Main(string[] args)
        {

            PopulateCSV();
        }

        private static void PopulateCSV()
        {
            var CarData = new List<Car>()
            {
                 new Car { Make  = "Ford", Model = "Fiesta", Colour = "Yellow", RegYear = 2010, Milleage = 50000, Price=3000, Sold = false }
                ,new Car { Make  = "Kia", Model = "Sportage", Colour = "White", RegYear = 2019, Milleage = 3000, Price=17000, Sold = false }

            };

            using (var writer = new StreamWriter("C:\\Users\\ckish.HS\\Source\\Repos\\colkish\\c-sharp\\MightyMotors\\MightyMotors\\MightMotorsCarSales.csv")) 
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(CarData);
            }

            
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int RegYear { get; set; }
        public int Milleage { get; set; }
        public int Price { get; set; }
        public bool Sold { get; set; }
    }


}
