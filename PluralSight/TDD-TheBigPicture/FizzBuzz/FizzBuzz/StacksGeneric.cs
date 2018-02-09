using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz
{
    public class StacksGeneric<T>
    {
        private List<T> _items = new List<T>();
        private int _currentIndex;
        private int _capacity;

        public StacksGeneric(int capacity)
        {
            _capacity = capacity;
            _items = new List<T>(_capacity);
        }

        public object GetStackItem(int index)
        {
            return _items.Count > 0 ? _items.GetRange(index, 1) : null;
        }

        public void Push(T item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
            else
            {
                throw new NullReferenceException("Cannot push null");
            }
        }

        public object Pop()
        {
            if (_items.Count > 0)
            {
                var items = _items[_items.Count - 1];
                _items.RemoveAt(_items.Count - 1);

                return items;
            }
            return default(T);
        }
    }
}
