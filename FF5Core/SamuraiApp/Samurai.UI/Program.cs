using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;

//Make this startup and reference the other 2 projects
namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //_context.Database.EnsureCreated(); //CREATES THE db FOR ME 
            //GetSamurai("Before Add:");
            //AddSamurai(); //one only
            //Add a list
            AddSamuraisByName("Col", "Sue", "Logan", "Mason"); //need to add 4 or more to trigger a bulk insert
            GetSamurais();
            Console.Write("Press any key...");
            Console.ReadKey();

        }


      

        //private static void AddSamurai() //one only
        private static void AddSamuraisByName(params string[] names) //allow a list
        { //comment the other one in and can see the DB persist !!!
            //var samurai = new Samurai { Name = "Colin" }; //one only
            //var samurai = new Samurai { Name = "Susan" };
            //_context.Samurais.Add(samurai); //one only
            //list
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            _context.SaveChanges();
        }


        //private static void GetSamurais(string text) // only if I want to display a whats passed in 
        private static void GetSamurais()
        {
            var samurais = _context.Samurais
                //TagWith puts a SQL comment when the command is executed, helps identify it in profiler...
                .TagWith("ConsoleApp.Program.GetSamurais method") //need to add using Microsoft.EntityFrameworkCore;
                .ToList(); //linq 

            Console.WriteLine($"Samurai count is {samurais.Count}"); // only if I want to display a whats passed in 
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

    }
}
