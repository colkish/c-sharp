using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataStructures
{ 
    //now for a different buffer class which uses the same interface
    public class Buffer<T> : IBuffer<T>
    {

        //Create a FIFO
        protected Queue<T> _queue = new Queue<T>(); //proected means can't be changed

        //virtual means can be changed
        public virtual bool IsEmpty
        {
            get { return _queue.Count == 0; }

        }
        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        /* moved to exenstion methods class as only used in certain cirumstances
        public IEnumerable<TOutput> AsEnumerableOf<TOutput>()
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in _queue)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }
        */

        //For enumerator nee to return IEnumerator<T> and IEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                ///.. do other stuff
                yield return item; //yeild is a special type for enumerators
            }
        }

        IEnumerator IEnumerable.GetEnumerator() //need using System.Collections; for this to work
        {
            return GetEnumerator();
        }

    }
}
