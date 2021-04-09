using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Employee[] devlopers = new Employee[]
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Colin" }
                ,new Employee {Id = 2, Name = "Susan" }
            };

            //if I hover over List or Employee and hit f12 it shows me the metedata for a list which includes IEnumerable<T>
            //very important for linq I can decalre them as IEnumerable
            //List<Employee> sales = new List<Employee>()
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 3, Name = "Logan" }
            };

            //nope this won't complie no iea why
            //List<Employee> enumerator = developers.GetEnumerator();

            fore


         }
    }
}
