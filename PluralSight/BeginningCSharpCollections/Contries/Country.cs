using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contries
{
    class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }

        //Define the default constructor, expects all of the above to be passed in
        public Country(string name, string code, string region, int poulation)
        {
            this.Name = name;
            this.Code = code;
            this.Region = region;
            this.Population = poulation;
        }
    }
}
