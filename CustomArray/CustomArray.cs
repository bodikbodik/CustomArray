using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        public int First { get; private set; }
        public int Last
        {
            get
            {
                return First + Length - 1;
            }
        }
        public int Length
        {
            get
            {
                return Array.Length;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("value was smaller than 0");
            }
        }
        public T[] Array
        {
            get;
            
        }
        public CustomArray(int first, int length)
        {
            First = first;
            Length = length;
            Array = new T[length];
        }
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list == null)
                throw new NullReferenceException("when list is null");
            if ((list as ICollection).Count <= 0)
            {
                throw new ArgumentException("when count is smaler than 0");
            }
            First = first;
            Array = list.ToArray();
        }
        public CustomArray(int first, params T[] list)
        {
            if (list == null)
                throw new ArgumentNullException("when list is null");
            if (list.Length <= 0)
            {
                throw new ArgumentException("when list without elements");
            }
            First = first;
            Array = list;
        }
        public T this[int item]
        {
            get
            {
                if( item < First || item > Last)
                    throw new ArgumentException("when index out of array range");
                return Array[item - First];
            }
            set
            {
                if (item < First || item > Last)
                    throw new ArgumentException("when index out of array range");
                if (value == null)
                    throw new ArgumentNullException("when value passed in indexer is null");
                Array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
