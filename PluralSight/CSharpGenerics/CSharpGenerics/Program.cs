using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGenerics
{

    public class EmployeeComparer : IEqualityComparer<Employee> , IComparer<Employee>//I just nee to create the implementation
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }

        public bool Equals(Employee x, Employee y)
        {
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }


    }

    //help to tidy my code
    public class DepartmentCollection : SortedDictionary<string,SortedSet<Employee>> 
    {

        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if(!ContainsKey(departmentName))
            { //add department if not already exists
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer())) ;
            }

            this[departmentName].Add(employee);
            return this;

        }

    }

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
            //We also have a sorted list , betror for looping through
            //Dictionaries are better for inserting and removing and looking up on key value

            employeesByName2.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByName2.Add("Engineering", new List<Employee> { new Employee(), new Employee() });

            foreach (var item in employeesByName2)
            {
                Console.WriteLine("The count of employees for {0} is {1}", item.Key, item.Value.Count);
            }

            //var deparments = new Dictionary<string, List<Employee>>();
            //var deparments = new SortedDictionary<string, HashSet<Employee>>(); //to sort be key
            //var deparments = new SortedDictionary<string, SortedSet<Employee>>(); //to sort be key & by Employee
            var departments = new DepartmentCollection(); //tidy up with a new class

            //deparments.Add("Sales", new HashSet<Employee>()); //try to make colin unique per department does not work it has an overload method IEqualityCompare which I can use defined above
            //deparments.Add("Sales", new HashSet<Employee>()); //try to make colin unique per department does not work it has an overload method IEqualityCompare which I can use defined above
            //deparments.Add("Sales", new HashSet<Employee>(new EmployeeComparer())); //instanciate with my new 
            /*
            departments.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));  //with a sorted list so that employees are sorted, need to implement iCompare 
            departments["Sales"].Add(new Employee { Name = "Mason" });
            departments["Sales"].Add(new Employee { Name = "Colin" });
            departments["Sales"].Add(new Employee { Name = "Colin" });
            //tidy up above now I have an add method
            */
            departments.Add("Sales", new Employee { Name = "Mason" })
                       .Add("Sales", new Employee { Name = "Colin" })
                       .Add("Sales", new Employee { Name = "Colin" });

            //deparments.Add("Engineering", new HashSet<Employee>());
            //deparments.Add("Engineering", new HashSet<Employee>());
            /*
            departments.Add("Engineering", new SortedSet<Employee>(new EmployeeComparer()));
            departments["Engineering"].Add(new Employee { Name = "Colin" });
            departments["Engineering"].Add(new Employee { Name = "Susan" });
            departments["Engineering"].Add(new Employee { Name = "Logan" });
            //tidy up above now I have an add method
            */
            departments.Add("Engineering", new Employee { Name = "Colin" })
                       .Add("Engineering", new Employee { Name = "Susan" })
                       .Add("Engineering", new Employee { Name = "Logan" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t"+ employee.Name);
                }
            }

        }
    }
}
