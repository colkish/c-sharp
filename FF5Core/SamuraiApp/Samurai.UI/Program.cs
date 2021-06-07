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
            _context.Database.EnsureCreated(); //CREATES THE db FOR ME ?
            GetSamurai("Before Add:");
            AddSamurai();
            GetSamurai("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();

        }

        private static void AddSamurai()
        { //comment the other one in and can see the DB persist !!!
            var samurai = new Samurai { Name = "Colin" };
            //var samurai = new Samurai { Name = "Susan" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamurai(string text)
        {
            var samurais = _context.Samurais.ToList(); //linq 
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

    }
}
