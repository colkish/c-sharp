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

            /* using a Dictionary
            //define countries as array of country objects as returned by the reader ReadFirstCounties method
            Dictionary<string, Country> countries = reader.ReadAllCountries(); //get the countries

            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry, there is not country with code. {userInput}");
            else
            {
                Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");
            }
            */

            //Using a list
            List<Country> countries = reader.ReadAllCountries();
            //get the countries
            //How to add and remove an item from an array(when it was a list )
            //Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            //int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            //countries.Insert(lilliputIndex, lilliput);
            //countries.RemoveAt(lilliputIndex);

            Console.Write("enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You muxt enter a +Version integer. Existing");
                return;
            }

            //declare a variable of type contry and loop though the countries array
            //foreach (Country country in countries)
            //int maxToDisplay = Math.Min(userInput, countries.Count);
            int maxToDisplay = userInput;
            // for (int i = 0; i < countries.Count; i++)
            for (int i = countries.Count - 1; i >= 0 ; i--)
            {
                int displayIndex = countries.Count - 1 - i;
                if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit>");
                    if (Console.ReadLine() != "")
                        break;
                }
                
                Country country = countries[i];// Add for a for loop
                //here I make the call to the class instead of a using statement above
                Console.WriteLine($"{displayIndex+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            //for a list much use counth and not length like we do for an array
            //Console.WriteLine($"{countries.Count} countries");

        }
    }
}
