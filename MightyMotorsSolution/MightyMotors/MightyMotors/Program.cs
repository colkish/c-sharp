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

            IEnumerable<Car> CarData = ReadCSV();

            string menuItem = "X" ;

            while (menuItem != "Q")
            { 
                menuItem = MainMenu();
                Console.WriteLine();

                if (menuItem.Equals("L"))
                {
                    ListAllCars(CarData); //must be a static method for me to pass in a variable like this
                };

                if (menuItem.Equals("S"))
                {
                    Search(CarData); //must be a static method for me to pass in a variable like this
                };
            };



        }

        private static void Search(IEnumerable<Car> carData)
        {
            Console.WriteLine("O:Search By Model");
            Console.WriteLine("A:Search By Make");
            var inputKey = Console.ReadKey().Key;

            inputKey.ToString();

            if (inputKey.Equals("O")) //###THIS DOESN'T PICK UP A O
            {
                SearchByModel(carData);
            }
                

        }

        private static void SearchByModel(IEnumerable<Car> carList)
        {
            Console.WriteLine("Model:");
            var model = Console.ReadLine();

            //for each and return will only work in here
            foreach (var car in carList)
            {
                if (car.Model.Equals(model))
                { 
                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", car.Id, car.Make, car.Model, car.Colour, car.RegYear, car.Milleage, car.Price, car.Sold);
                }
            }

            Console.WriteLine();
        }

        private static string MainMenu()
        {
            Console.WriteLine("L:List All");
            Console.WriteLine("S:Search");
            Console.WriteLine("A:Add Car");
            Console.WriteLine("M:Mark as Sold");
            Console.WriteLine("Q:Quit");
            var inputKey = Console.ReadKey().Key;

            return inputKey.ToString();
        }

        private static IEnumerable<Car> ReadCSV()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

        //think I need to do this without a using block
        //C# using statement makes sure that the allocated objects within the using statement is disposed once the using block code is executed.
        //using (var reader = new StreamReader("C:\\Users\\ckish.HS\\Source\\Repos\\colkish\\c-sharp\\MightyMotors\\MightyMotors\\MightMotorsCarSales.csv"))

        //using (var csv = new CsvReader(reader, configuration))
        //{

        //    csv.Context.RegisterClassMap<PersonMap>();
        //    var CarData = csv.GetRecords<Car>();
        //    return CarData;
        //}

           var reader = new StreamReader("C:\\Users\\ckish.HS\\Source\\Repos\\colkish\\c-sharp\\MightyMotorsSolution\\MightyMotors\\MightMotorsCarSales.csv");
                
            var csv = new CsvReader(reader, configuration);

            csv.Context.RegisterClassMap<PersonMap>();
            var CarData = csv.GetRecords<Car>();
            return CarData;

        }

        private static void ListAllCars(IEnumerable<Car> carList)
        {
            Console.WriteLine();
            Console.WriteLine("Id|Make|Model|Colour|RegYear|Milleage|Price|Sold");

            //for each and return will only work in here
            foreach (var car in carList)
            {
                Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", car.Id, car.Make, car.Model, car.Colour, car.RegYear, car.Milleage, car.Price, car.Sold);
            }

            Console.WriteLine();

        }

    }


    public class PersonMap : ClassMap<Car>
    {
        public PersonMap()
        {
            Map(p => p.Id).Index(0);
            Map(p => p.Make).Index(1);
            Map(p => p.Model).Index(2);
            Map(p => p.Colour).Index(3);
            Map(p => p.RegYear).Index(4);
            Map(p => p.Milleage).Index(5);
            Map(p => p.Price).Index(6);
            Map(p => p.Sold).Index(7);

        }

    }
}
