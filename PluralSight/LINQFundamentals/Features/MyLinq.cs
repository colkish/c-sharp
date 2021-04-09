using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {

        //if I add this it makes it an extension method intelli sense shows this as a dow arrow
        //Thiknk I need to do the gernatic course and then back to this one to understand this...
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
