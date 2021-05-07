using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{

    //for demo purposes I have called the file model and will put many classes in it, normally one class per file
    public class Person
    {
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public virtual void DoWork()
        {
            Console.WriteLine("Doing real work");
        }
    }
    public class Manager : Employee
    { 
        public override void DoWork()
        {
            Console.WriteLine("Creating a meeting");
        }
    }

}
