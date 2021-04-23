using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //CTRL M THEN CTLR R to refractor extract, create a method

            //generics allow us to reuse code whilst still being type safe.  So we create with a palceholder for a type and the calling client instanciates the type.
            //var buffer = new CircularBuffer(capacity: 3);
            var buffer = new CircularBuffer<double>(capacity: 3);

            ProcessInput(buffer);

            foreach (var item in buffer) //I need a enumerable inferace to do this
            {
                Console.WriteLine(item);
            }

            ProcessOutput(buffer);
        }

        //private static void ProcessOutput(CircularBuffer<double> buffer)
        private static void ProcessOutput(IBuffer<double> buffer) //using interfaces
        {
            var sum = 0.0; //sum buffer
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                //var value = buffer.Read();
                //if (value is double) //have to check its a double 1st
                //sum += (double)value; //sum buffer need to force it into a double, but what if I put a string in
                sum += buffer.Read();
                //Console.WriteLine("\t"+ buffer.Read()); //dump out buffer
                //but using an object is also very inefficent as ildasm in "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools"
                //pointed to the exe for this project showns us that the main program uses a box which is very bad for memory if you box/unbox a lrge number of value types
                //hence generics which retains strongle typed
            }
            Console.WriteLine(sum); //sum buffer
        }

        //private static void ProcessInput(CircularBuffer<double> buffer)
        private static void ProcessInput(IBuffer<double> buffer) //using interfaces
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
