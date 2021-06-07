using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips
{

    public enum Steps
    {
        Step1,
        Step2,
        Step3

    }

    public static class StringEntensions
    {
        public static TEnum ParseEnum<TEnum>(this string value) where TEnum: struct //can's resrict it to a Enum
        {
            return (TEnum) Enum.Parse(typeof(TEnum), value);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = "Step1";
            //can cast it like this
            //Steps value = (Steps)Enum.Parse(typeof(Steps), input);
            var value = input.ParseEnum<Steps>(); //would like to do this, if we create ParseEnum as a string extension in the steps class we can do thi
            Console.WriteLine(value);
            //var fail = input.ParseEnum<int>(); //this would fail doesn't work for an enum
        }
    }
}
