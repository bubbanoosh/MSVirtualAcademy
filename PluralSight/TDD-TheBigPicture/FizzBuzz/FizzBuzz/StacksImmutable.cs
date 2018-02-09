using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class StacksImmutable<T>
    {
        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public StacksImmutable()
        {
            _count = 0;
        }

        public StacksImmutable(int count)
        {
            _count = count;
        }


        public StacksImmutable<T> Push(T item)
        {
            return new StacksImmutable<T>();
        }

        public StacksImmutable<T> Peek()
        {
            return this;
        }

        //public object Pop()
        //{
        //    if (_items.Count > 0)
        //    {
        //        var items = _items[_items.Count - 1];
        //        _items.RemoveAt(_items.Count - 1);

        //        return items;
        //    }
        //    return default(T);
        //}
    }
}
