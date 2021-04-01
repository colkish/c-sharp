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
            //List<Country> countries = reader.ReadAllCountries();

            //using a dict
            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
            //list all regions
            foreach (string region in countries.Keys)
                Console.WriteLine(region);

            Console.Write("Which of the above regions do you want? ");
            string chosenRegion = Console.ReadLine();

            //reader.RemoveCommaCountries(countries); //to remove countores with commas

            //get the countries
            //How to add and remove an item from an array(when it was a list )
            //Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            //int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            //countries.Insert(lilliputIndex, lilliput);
            //countries.RemoveAt(lilliputIndex);

            /*get input for number to display
             Console.Write("enter no. of countries to display> ");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must enter a +Version integer. Existing");
                return;
            }
            */

            //declare a variable of type contry and loop though the countries array
            //foreach (Country country in countries) //foreach is read only gets all the countries

            //foreach (Country country in countries.Take(10)) //use link to restrict to the next 10 
            //can't batch with link, use a for loop
            //            foreach (Country country in countries.OrderBy(x => x.Name).Take(10))//using linq use a lamda function to pass into order by 
            //filter with link
            //var filteredCountries = countries.Where(x => !x.Name.Contains(','));//.Take(20);
            //using linq query
            /*
             * var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country; //same as code above but cant do a take 20 in LINQ query it's only subset of LINQ methods
            */
            //foreach (Country country in filteredCountries2)
                //int maxToDisplay = Math.Min(userInput, countries.Count);
                //int maxToDisplay = userInput;
                //for (int i = 0; i < countries.Count; i++) //forward earnings
                //for (int i = countries.Count - 1; i >= 0 ; i--) //reverse order
                if (countries.ContainsKey(chosenRegion))
                {
                    foreach (Country country in countries[chosenRegion].Take(10))
                    //int displayIndex = countries.Count - 1 - i; //reverse
                    // if (i > 0 && (i % maxToDisplay == 0))
                    //must reverse through a list if deleting (or inserting) otherwise when I delete and the index changes I miss checking an item in the list
                    //  if (displayIndex > 0 && (displayIndex % maxToDisplay == 0)) //reverse
                    /* ask for user input
                     {
                         Console.WriteLine("Hit return to continue, anything else to quit>");
                         if (Console.ReadLine() != "")
                             break;
                     }
                     */
                    //Country country = countries[i];// Add for a for loop
                    //here I make the call to the class instead of a using statement above
                    //Console.WriteLine($"{i+1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}"); //forward
                    //Console.WriteLine($"{displayIndex + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}"); //reverse
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
                   
                }
                else
                {
                Console.WriteLine("Taht is not a valid region");
                }

            //prove link does not remove the countries with comma's
            //for (int i= 12; i<=14; i++)
            //{
              //  Console.WriteLine(countries[i].Name);
           // }

            //for a list much use count and not length like we do for an array
            //Console.WriteLine($"{countries.Count} countries");

        }
    }
}
