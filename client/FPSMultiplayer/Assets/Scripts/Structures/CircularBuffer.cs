using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class CircularBuffer<TValue> : IEnumerable<TValue>
    {
        private readonly TValue[] _values;
        private int _currentIndex;
        
        public CircularBuffer(int size)
        {
            Size = size;
            _values = new TValue[size];
        }

        public int Size { get; }
        
        public void Add(TValue value)
        {
            _values[_currentIndex] = value;
            _currentIndex++;

            if (_currentIndex > _values.Length - 1)
                _currentIndex = 0;
        }

        public IEnumerator<TValue> GetEnumerator() => 
            ((IEnumerable<TValue>)_values).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}