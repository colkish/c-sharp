using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contries; //add project to references and do a using on the namespace here

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finalnd", "FIN", "Europe", 5_211_303);

            var countries = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, finland }
            };

            //Not exists throws an expection
            //Console.WriteLine(countries["MUS"].Name);

            //do like this
            bool exists = countries.TryGetValue("MUS", out Country country);
            if (exists)
                Console.WriteLine(country.Name);
            else
                Console.WriteLine("There is no country with the code MUS");

            // foreach (Country country in countries.Values)
            //    Console.WriteLine(country.Name);

            //Country selectCountry = countries["NOR"];
            //Console.WriteLine(selectCountry.Name);
        }
    }
}
