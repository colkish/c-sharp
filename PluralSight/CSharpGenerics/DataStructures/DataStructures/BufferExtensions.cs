using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    //this is a delegate
    //public delegate void Printer(object data); //no make this take a generic
    //public delegate void Printer<T>(T data); //now replaced by an action

    public static class BufferExtensions
    {


        //public static void Dump<T> (this IBuffer<T> buffer, Printer<T> print) //now replaced with action
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
                //Console.WriteLine(item); rplaced with a generaic print delegate
            }

        }

        /*
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }*/

        //better way to do the above
        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            /*foreach (var item in buffer)
            {
                TOutput result = converter(item) ;
                yield return result;
            }*/
            //better than a loop
            return buffer.Select(i => converter(i)); 

        }

    }
}
