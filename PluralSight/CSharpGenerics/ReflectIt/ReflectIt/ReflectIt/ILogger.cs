using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    public class ILogger
    {
        
    }

    public class SqlServerLogger : ILogger
    {

    }

    public interface IRepository<T>
    {

    }

    public class SqlRepository<T> : IRepository<T>
    {
        public SqlRepository(ILogger logger)
        {

        }
    }

    public class Customer 
    {

    }

    public class InvoiceService
    {
        //public InvoiceService(IRepository<Employee> repository,ILogger lo) //invoice to employee works
        public InvoiceService(IRepository<Customer> repository, ILogger lo) //invoice to customer does not work
        {

        }

    }
}
