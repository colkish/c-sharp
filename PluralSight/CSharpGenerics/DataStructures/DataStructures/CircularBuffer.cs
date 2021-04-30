using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    //public class CircularBuffer
    //public class CircularBuffer<T> //generic type
//    public class CircularBuffer<T> : IBuffer<T> //generic type which implements an interface
    public class CircularBuffer<T> : Buffer<T> //generic type which inherits from buffer
    {

        //special case of buffer with a capacity
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;

        }

        //override the write method so it's circular
        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
        }

        //need a is full method but not in the interface as it only really applies to curcular as nornal buffer is never full
        public bool IsFull { get { return _queue.Count == _capacity; } }

        /* orginal now replaced using a generic queue
            //private double[] _buffer ; // so like this it only works with doubles, 
            //private object[] _buffer; // so now it would work with strings not strongly typed
            private T[] _buffer;
            private int _start;
            private int _end;

            //no capacity passed
            public CircularBuffer() : this(capacity:10)
            {
            }

            //overload to pass in capacity
            public CircularBuffer(int capacity)
            {
                //_buffer = new double[capacity + 1];
                _buffer = new T[capacity + 1];
                _start = 0;
                _end = 0;
            }

         //    public void Write(double value)
            public void Write(T value)
            {
                _buffer[_end] = value;
                _end = (_end + 1) % _buffer.Length;
                if (_end == _start)
                {
                    _start = (_start + 1) % _buffer.Length;
                }
            }

            //public double Read()
            public T Read()
            {
                var result = _buffer[_start];
                _start = (_start + 1) % _buffer.Length;
                return result;

            }

            public int Capacity
            {
                get { return _buffer.Length; }
            }

            public bool IsEmpty
            {
                get { return _end == _start; }
            }

            public bool IsFull
            {
                get { return (_end + 1) % _buffer.Length == _start; }
            }

    */
    }
}
