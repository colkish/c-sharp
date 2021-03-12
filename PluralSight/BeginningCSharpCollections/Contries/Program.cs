using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contries
{
    class Program
    {
        static void Main(string[] args)
        {
            //defint he filepath
            string filePath = @"C:\Users\ckish.HS\OneDrive - hublsoft limited\PDP\C#\BeginningCSharpCollections\csharp-collections-beginning\Pop by Largest Final.csv";
            //instanciate a csv reader passing in the filepath
            CsvReader reader = new CsvReader(filePath);

            //define countries as array of country objects as returned by the reader ReadFirstCounties method
            List<Country> countries = reader.ReadAllCountries(); //get the countries
            Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x=>x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);

            //decalre a variable of type contry and loop though the countries array
            foreach (Country country in countries)
            {                       //here I make the call to the class instead of a using statement above
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}") ;
            }
            //for a list much use counth and not length like we do for an array
            Console.WriteLine($"{countries.Count} countries");

        }
    }
}
