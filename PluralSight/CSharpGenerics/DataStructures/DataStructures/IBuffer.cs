using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    //Now I am going to create interface methods for my buffer of type T for all buffers
    public interface IBuffer<T> : IEnumerable<T> //make this interface enumerable, which I need to define 
    {
        bool IsEmpty { get; } //is empty that is a get
        void Write(T value); //write methos tha takes value of type T

        //now I want to return a different generic type
        //must impleent in any clasees that use this interafce I.e. the buffer
      
        //Now I have moved this into extension methods class so don't define in interface
        //IEnumerable<TOutput> AsEnumerableOf<TOutput>();

        T Read(); //read methos that returns T

    }
}
