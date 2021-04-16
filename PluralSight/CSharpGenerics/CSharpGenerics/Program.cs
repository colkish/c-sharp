using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            //The queue first in first out of type T so we can use any type and it will be type safe, type employee
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(new Employee { Name = "Colin" });
            queue.Enqueue(new Employee { Name = "Susan" });
            queue.Enqueue(new Employee { Name = "Logan" });

            while (queue.Count > 0)
            {
                var employee = queue.Dequeue();
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("----");

            //A stack is first in last out, type employee
            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee { Name = "Colin" });
            stack.Push(new Employee { Name = "Susan" });
            stack.Push(new Employee { Name = "Logan" });

            while (stack.Count > 0)
            {
                var employee = stack.Pop();
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("----");

            //Has sets must be unique, type int
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2); //returns true
            set.Add(2); //dup so isn't added returns false
            //can't index can be any any order

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----");

            //Has set with employee
            HashSet<Employee> setEmp = new HashSet<Employee>();
            setEmp.Add(new Employee { Name = "Colin" });
            setEmp.Add(new Employee { Name = "Colin" }); //these are not dupes as these are reference values
            var emp = new Employee { Name = "Susan" };
            setEmp.Add(emp); //it won't add these twice as they are the same reference variable
            setEmp.Add(emp);

            foreach (var item in setEmp)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("----");

            //Linked list
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(3);
            var first = list.First;
            list.AddAfter(first, 5);
            list.AddBefore(first, 10);

            //can loop though using this 
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----");

            //or like this
            var node = list.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            //Dictionary key must be uniue so would normally use an id
            var employeesByName = new Dictionary<string, Employee>();
            employeesByName.Add("Colin", new Employee { Name = "Colin" });
            employeesByName.Add("Susan", new Employee { Name = "Susan" });
            employeesByName.Add("Logan", new Employee { Name = "Logan" });

            var scott = employeesByName["Colin"];

            foreach (var item in employeesByName)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value.Name);
            }

            Console.WriteLine("----");

            //What about if TValue is a list
            var employeesByDepartment = new Dictionary<string, List<Employee>>();

            employeesByDepartment.Add("Engineering", new List<Employee> { new Employee { Name = "Colin" } });

            employeesByDepartment["Engineering"].Add(new Employee { Name = "Susan" });


            foreach (var item in employeesByDepartment)
            {
                foreach (var employee in item.Value)
                {
                    Console.WriteLine(employee.Name);

                }

            }

            Console.WriteLine("----");

            //In no order
            //var employeesByName2 = new Dictionary<string, List<Employee>>();
            //so would use sort order      
            var employeesByName2 = new SortedDictionary<string, List<Employee>>(); //sorts by key

            employeesByName2.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByName2.Add("Engineering", new List<Employee> { new Employee(), new Employee() });

            foreach (var item in employeesByName2)
            {
                Console.WriteLine("The count of employyees for {0} is {1}", item.Key, item.Value.Count);
            }
        
            
       }
    }
}
