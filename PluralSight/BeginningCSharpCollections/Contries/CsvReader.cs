using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Contries
{
    class CsvReader
    {
        //provate backing feild, so use an _
        private string _csvFilePath;

        //define the constructor expects filepath to be passed in
        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        //method to read x countries from a file it refurns an array of countries
        public Country[] ReadFirstNCountriers (int nCountries)
        {
            //define countries as an array of nCountries countries and return the array
            //this is a reference array so all it's values will be null, if it was a value type like an int then it would have 0 values if it's values are not set
            Country[]  countries = new Country[nCountries]; //I define the size here in squares, and it must have a size

            //StreamReader is a class in the System.IO so need to add a using for this above
            //StreamReader sr = new StreamReader(_csvFilePath);
            //A using statement disposes of stream reader when it's finished, important as it locks the file!
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //reader the header doing nothing
                sr.ReadLine();

                //setup a for loop for 10 countries and populate the 
                for (int i = 0; i < nCountries; i++)
                {
                    string csvLine = sr.ReadLine(); //grab live
                    //populate array by calling readline from CSV
                    countries[i] = ReadCountryFromCsvLine(csvLine);
                }


            }
            
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            //parts is an aray which we split form the csv line
            string[] parts = csvLine.Split(new char[] { ',' });

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]); //this will return a string so parse it

            //returns a new instance of an array
            return new Country(name, code, region, population);
        }
    }
}
