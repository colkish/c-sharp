﻿using System;
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
        public List<Country> ReadAllCountries ()
        {
            //define countries as an array of nCountries countries and return the array
            //this is a reference array so all it's values will be null, if it was a value type like an int then it would have 0 values if it's values are not set
            List <Country>  countries = new List<Country>(); //I define the size here in squares, and it must have a size

            //StreamReader is a class in the System.IO so need to add a using for this above
            //StreamReader sr = new StreamReader(_csvFilePath);
            //A using statement disposes of stream reader when it's finished, important as it locks the file!
            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //reader the header doing nothing
                sr.ReadLine();

                //setup a for loop for countries and populate
                string csvLine;
                while ((csvLine = sr.ReadLine()) != null) //grab line
                { 
                    //populate array by calling readline from CSV
                    countries.Add(ReadCountryFromCsvLine(csvLine));
                }


            }
            
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            //parts is an aray which we split form the csv line
            string[] parts = csvLine.Split(new char[] { ',' });
            string name;
            string code;
            string region;
            string popText;
            switch (parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;
                case 5:
                    name = parts[0] + ", " + parts[1];
                    name = name.Replace("\"", null).Trim();
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from csvLin: {csvLine}");

            }

            int.TryParse(popText, out int population);

            //returns a new instance of an array
            return new Country(name, code, region, population);
        }
    }
}
