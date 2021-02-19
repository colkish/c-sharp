using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class LogginService
    {

        public static void WriteToFile (List<ILoggable> itemsToLog)
        {
            foreach (var item in itemsToLog)
            {//so this is the true power of interface polymorphism, it calls the log method in the oppropriate object (customer, product etc...) through it iloggable interface
                Console.WriteLine(item.Log());
            }

        }

    }
}
