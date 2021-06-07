using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips4
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Item();
            //var b = new Item();
            //var c = new Item();

            //Console.WriteLine(Item.InstanceCount); //shows 3 what if I pass in a generic type

            var a = new Item<int>();
            var b = new Item<int>();
            var c = new Item<string>();

            //now need to pass in the type on a writeline
            Console.WriteLine(Item<int>.InstanceCount); //2
            Console.WriteLine(Item<string>.InstanceCount); //1

            //this read better
            Console.WriteLine(Item.InstanceCount); //2
            Console.WriteLine(Item.InstanceCount); //1

        }
    }


    //public class Item as generic
    //public class Item<T>
    public class Item<T> : Item //base class
    {

        //move this to base class
        //public Item()
        //{
        //    InstanceCount += 1;

        //}

        //public static int InstanceCount; //static so shared accross all instances
        
    }

    public class Item
    {

        public Item()
        {
            InstanceCount += 1;

        }

        public static int InstanceCount; //static so shared accross all instances

    }

}
