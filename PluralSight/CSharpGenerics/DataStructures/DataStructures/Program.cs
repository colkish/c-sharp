using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {

        //same sginature of delegate Printer
        //static void ConsoleWrite(double data)
        //{
         //   Console.WriteLine(data);
        //}

        static void Main(string[] args)
        {
            //CTRL M THEN CTLR R to refractor extract, create a method

            //generics allow us to reuse code whilst still being type safe.  So we create with a palceholder for a type and the calling client instanciates the type.
            //var buffer = new CircularBuffer(capacity: 3);
            //var buffer = new CircularBuffer<double>(capacity: 3);

            //But I can use action instead of my printer delegate
            //Action<double> print = ConsoleWrite; 
            //using an anynomus delegate
            /*Action<double> print = delegate(double data)
            {
                Console.WriteLine(data);
            };*/
            //using lambda
            //Action is a void
            Action<Boolean> print = d => Console.WriteLine(d);

            //Func must return, last aurgument is always the return type
            //These are how linq works
            Func<double,double> square = d => d * d ;
            Func<double, double, double> add = (x, y) => x + y;

            //Predicate aways returns a boolean
            Predicate<double> isLessThanTen = d => d < 10;

            //this then allows us to do things like this:
            print(isLessThanTen(square(add(3, 5))));

            //var buffer = new Buffer<double>();
            //lets use a circular buffer to demo events
            var buffer = new CircularBuffer<double>(capacity:3);
            //creates a event handler for ItemDisgarded
            buffer.ItemDisgarded += ItemDisgarded; //hit tab tab for c# to create the template code
            //now we want to know when we hit capcity, best way is to reaise an event when we dequeue

            //using the convert to ints
            //var asInts = buffer.AsEnumerableOf<double, int>();



            //var consoleOut = new Printer<double>(ConsoleWrite); //actuall dont need this
            //buffer.Dump(); //buffer.Dump<double>(); dont have to do this as it already knows buffer is a double
            //buffer.Dump(consoleOut); //now with printer delegate
            //buffer.Dump(ConsoleWrite); //without variable definition
            //using the action ConsoleWrite
            buffer.Dump(d => Console.WriteLine(d));


            ProcessInput(buffer);

            //this won't work as AsEnumerableOf uses GetConverter which can't do a double to an dattime so throws an error
            //var asDates = buffer.AsEnumerableOf<double, DateTime>();
            //lets look at built in coverter delegate
            //Converter<double, DateTime> converter = d => new DateTime(2010,1,1).AddDays(d);
            //can just pass in the lamda like this
            var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d)); //using map name
            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }


            //foreach (var item in buffer) //I need a enumerable inferace to do this - done
            /*
             foreach (var item in asInts) //loop through ints
            {
                Console.WriteLine(item);
            }
            */

            ProcessOutput(buffer);
        }

        private static void ItemDisgarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full. Discarding {0} New Item {1}", e.ItemDisgarded, e.NewItem);
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
