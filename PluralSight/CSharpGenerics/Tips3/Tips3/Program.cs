using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<Item<int>>() ; //now definit as the base class
            var list = new List<Item>();
            list.Add(new Item<int>());
            list.Add(new Item<double>()); //this wont work unless I define a base class with no generics
    }

    public class Item<T> :Item 
    {
    }

    public class Item
    {

    }
}
