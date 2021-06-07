using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nrmally do this
            //var employeeList = new List<Employee>() ;

            //var employeeList = CreateCollection(typeof(List<Employee>));
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            //see if this works by outputting the name of the collection
            Console.Write(employeeList.GetType().Name);
            //Console.WriteLine(employeeList.GetType().FullName);
            var genericAuguments = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericAuguments)
            {
                Console.Write("[{0}]", arg.Name);
            }
            Console.WriteLine();

            var employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employee, null);
        }

        //private static object CreateCollection(Type type)
        private static object CreateCollection(Type collectionType, Type itemType)
        {
            //return Activator.CreateInstance(type);
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string name { get; set; }

        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);

        }


    }
}
