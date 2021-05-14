using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //EF Class

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {

            //Download EF right click references -> manage nuget packages => browse tab => select EF and install => then add using as above
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());//create a new bd that's al;ways dropeed and re-created            

            using (IRepository<Employee> employeeRepository = new SqlReposistory<Employee>(new EmployeeDb())) 
            {
                AddEmployees(employeeRepository);
                AddManagers(employeeRepository);
                CountEmployees(employeeRepository);
                QueryEmployee(employeeRepository);
                DumpPeople(employeeRepository); //using covariants here 

                //this is fine
                //IEnumerable<Employee> temp = employeeRepository.FindAll();
                ///so is this
                IEnumerable<Person> temp = employeeRepository.FindAll();
                //so why doesn't this work: cos IEnumerable is coveriant i.e has the out keyword
                //private static void DumpPeople(IRepository<Person> employeeRepository)


            };
        }

        //works fine
        //private static void AddManagers(IRepository<Employee> employeeRepository)
        //this doesn't
        //private static void AddManagers(IRepository<Manager> employeeRepository)
        //now if I make it a write only all is good
        private static void AddManagers(IWriteOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "Logan" });
            employeeRepository.Commit();
        }


        //private static void DumpPeople(IRepository<Employee> employeeRepository)
        //cant do the following yet would think you could as Employee derives from person
        private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static void QueryEmployee(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.findById(1);
            Console.WriteLine(employee.Name);
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count());
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Colin" });
            employeeRepository.Add(new Employee { Name = "Susan" });
            employeeRepository.Commit();
        }
    }
}
