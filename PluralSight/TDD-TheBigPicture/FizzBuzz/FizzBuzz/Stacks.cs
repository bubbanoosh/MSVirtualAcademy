using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class Stacks
    {
        private object[] _items;
        private int _currentIndex;
        private int _capacity;

        public Stacks(int capacity)
        {
            _capacity = capacity;
            _items = new object[_capacity];
            _currentIndex = 0;
        }

        public object GetStackItem(int index)
        {
            return _items.Length > 0 ? _items.GetValue(index) : null;
        }

        public void Push(object item)
        {
            if (item != null)
            {
                _items[_currentIndex] = item;
                _currentIndex++;
            }
            else
            {
                throw new NullReferenceException("Cannot push null");
            }
        }

        public object Pop()
        {
            if (_currentIndex > 0)
            {
                var item = _items[_currentIndex - 1];
                _currentIndex--;

                return item;
            }
            return null;
        }
    }
}
