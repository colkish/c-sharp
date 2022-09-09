using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CreateCSV;
using CsvHelper;
using CsvHelper.Configuration;

namespace MightyMotors
{
    class Program
    {

        static void Main(string[] args)
        { 

            IEnumerable<Car> CarData = ReadSCV();

            //for each and return will only work in here
            foreach (var car in CarData)
            {
                Console.WriteLine(car.Make);  
            }

        }

        private static IEnumerable<Car> ReadSCV()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader("C:\\Users\\ckish.HS\\Source\\Repos\\colkish\\c-sharp\\MightyMotors\\MightyMotors\\MightMotorsCarSales.csv"))
            
            //think I need to do this without a using block
            using (var csv = new CsvReader(reader, configuration))
            {

                csv.Context.RegisterClassMap<PersonMap>();
                var CarData = csv.GetRecords<Car>();
                return CarData;
            }

        }

    }

    public class PersonMap : ClassMap<Car>
    {
        public PersonMap()
        {
            Map(p => p.Make).Index(0);
            Map(p => p.Model).Index(1);
            Map(p => p.Colour).Index(2);
            Map(p => p.RegYear).Index(3);
            Map(p => p.Milleage).Index(4);
            Map(p => p.Price).Index(5);
            Map(p => p.Sold).Index(6);

        }

    }
}
