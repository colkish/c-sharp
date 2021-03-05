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
            Country[] countries = reader.ReadFirstNCountriers(10); //get the first 10

            //decalre a variable of type contry and loop though the countries array
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Population}: {country.Name}") ;
            }

        }
    }
}
