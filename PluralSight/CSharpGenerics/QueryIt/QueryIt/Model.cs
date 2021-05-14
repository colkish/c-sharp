using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{

    public interface IEntity
    {
        bool IsValid();
    }

    //for demo purposes I have called the file model and will put many classes in it, normally one class per file
    public class Person
    {
        public string Name { get; set; }
    }
    public class Employee : Person, IEntity //this interface then enforces me to use a isvalid method
    {
        public int Id { get; set; }
        
        public bool IsValid() //EF has it's own validation build in code
        {
            return true;
        }

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
