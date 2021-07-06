using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Collections.Generic;

//Make this startup and reference the other 2 projects
namespace SamuraiApp.UI
{
    class Program
    {
        //SamuraiContext class is a DBconbtect so it tracks this data in the context and then same the changes back to the DB
        private static SamuraiContext _context = new SamuraiContext();
        private static SamuraiContext _contextNT = new SamuraiContextNoTracking();

        static void Main(string[] args)
        {
            //_context.Database.EnsureCreated(); //CREATES THE db FOR ME 
            //GetSamurai("Before Add:");
            //AddSamurai(); //one only
            //Add a list
            //AddSamuraisByName("Col", "Sue", "Logan", "Mason"); //need to add 4 or more to trigger a bulk insert
            //AddVariousTypes();
            //GetSamurais();
            //QueryFilters();
            //QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetreieveAndUpdateMultipleSamurais();
            //RetreieveAndDeleteASamurai();
            //QueryAndUpdateBattles();
            //InsertNewSamuraiWithAQuote();
            //AddQuoteToExistingSamuraiWhileTracked();
            //AddQuoteToExistingSamuraiNotTracked(2);
            //this is an better way to do it using the FK
            //Simpler_AddQuoteToExistingSamuraiNotTracked(2);
            EagerLoadingSamuraiWithQuotes();
            Console.Write("Press any key...");
            Console.ReadKey();

        }

        private static void EagerLoadingSamuraiWithQuotes()
        {
            //this will do a single query with a left join i.e. samurais to quotes
            //default
            //var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
            //can also split the query using this option if you think performance is better
            var samuraiWithQuotes = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();
        }

        private static void Simpler_AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var quote = new Quote { Text = "Time to go", SamuraiId = samuraiId };
            using var newContext = new SamuraiContext();
            newContext.Quotes.Add(quote);
            newContext.SaveChanges();
        }

        //Add, update and remove methods are all auto built into db context
        //also there is an attach method

        private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "Time to go"
            });
            //use using so connection is auto disposed once done
            using (var newContext = new SamuraiContext())
            {
                newContext.Samurais.Attach(samurai); //using attach then we still gett the quote added, with no
                //newContext.Samurais.Update(samurai); //an update causes an update to samurai, which is not need use attach thats better
                newContext.SaveChanges();
            }
        }

        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote
            {
                Text = "Watch out"
            });
            _context.SaveChanges();
        }

        private static void InsertNewSamuraiWithAQuote()
        {
            var samurai = new Samurai
            {
                 Name = "Colin"
                ,Quotes = new List<Quote>
                {
                    new Quote{Text = "What is for tea"},
                    new Quote{Text = "It's bed time"} //would be a merge if 4 or more quotes
                }
            };
            _context.Samurais.Add(samurai); //maks in the context whats been added
            _context.SaveChanges(); //then makes change to the DB

        }

        //add some samurai and battles but they are not connected in a relationship
        private static void AddVariousTypes()
        {
            //can do this rather than below
            _context.AddRange
                (
                 new Samurai { Name = "John" }
                , new Samurai { Name = "Kristy" }
                , new Battle { Name = "Battle of 72" }
                , new Battle { Name = "Battle of 14" }
                );
            //_context.Samurais.AddRange
            //    (
            //     new Samurai { Name = "John" }
            //    ,new Samurai { Name = "Kristy" }
            //    );
            //_context.Battles.AddRange
            //    (
            //    new Battle { Name = "Battle of 72" }
            //    , new Battle { Name = "Battle of 14" }
            //    );
            _context.SaveChanges();

        }

        private static void AddSamurais(Samurai[] samurais)
        {
            //AddRange can take an array or an IEnumerable e.g. List<Samurai>
            _context.Samurais.AddRange(samurais);
            _context.SaveChanges();
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
            var samurais = _contextNT.Samurais
            //var samurais = _context.Samurais
                //TagWith puts a SQL comment when the command is executed, helps identify it in profiler...
                .TagWith("ConsoleApp.Program.GetSamurais method") //need to add using Microsoft.EntityFrameworkCore;
                .ToList(); //linq 

            //put a breakpoint here and the do a quick watch on _context.ChangeTracker.Entries() or _contextNT.ChangeTracker.Entries()
            //for _context.Samurais I see the trakded results for _contextNT.Samurais there is non tracked results
            Console.WriteLine($"Samurai count is {samurais.Count}"); // only if I want to display a whats passed in 
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        public static void QueryFilters()
        {
            //would normally be a vraible like this
            //var name = "Colin";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList(); //converts to a paremeterised query

            //var samurais = _context.Samurais.Where(s => s.Name == "Colin").ToList(); //has a hard coded predicate

            //wildcard search like this
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
            //paramterised
            var search = "J%"; //to list must come after a where
            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, search)).ToList();
        }

        public static void QueryAggregates()
        {
            //var name = "Colin"; //first or default will do a top 1
            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
            //or can use find, a debset method which finds based on a key value and is very efficient
            var samurai = _context.Samurais.Find(2);

        }

        public static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Kish";
            _context.SaveChanges();
        }

        public static void RetreieveAndUpdateMultipleSamurais()
        {//skip and take great for paging data
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => s.Name += "Kish");
            _context.SaveChanges();
        }

        public static void RetreieveAndDeleteASamurai()
        {
            var samurai = _context.Samurais.Find(18);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }

        //This deals with a disconnected scenario
        public static void QueryAndUpdateBattles()
        {
            List<Battle> disconnectedBattles;
            using (var contex1 = new SamuraiContext())
            {
                disconnectedBattles = _context.Battles.ToList();
            } //context1 is disposed
            disconnectedBattles.ForEach(b =>
                {
                    b.StartDate = new DateTime(1570, 01, 01);
                    b.EndDate = new DateTime(1570, 12, 01);
                });
            using (var context2 = new SamuraiContext())
            {
                context2.UpdateRange(disconnectedBattles); //here I use an update command I didn't have to does this when I wasn't disconnected as the code was tracking the context, not this update will update all the columns as it has no idea which ones have changed as it hasn;t been trakcing the context
                context2.SaveChanges();
            }
        }
    }
}
