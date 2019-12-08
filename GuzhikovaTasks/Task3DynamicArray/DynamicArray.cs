using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class DynamicArray<T> : IList<T>
    {
        public DynamicArray()
        {
            _dynamicArray = new T[_capacity];


        }

        public DynamicArray(int capacity)
        {
            _capacity = capacity;
            _dynamicArray = new T[_capacity];
        }

        public DynamicArray(List<T> list)
        {
            _capacity = list.Count;
            _dynamicArray = new T[_capacity];

            CopyListToArray(list);
        }

        T[] _dynamicArray;
        private int _count = 0;

        private int _capacity = 8;

        public int Capacity
        {
            get { return _capacity; }
        }


        // !!! В пункте 3.3.8 нужно было создать свойство Length. В моем случае свойство Count является его аналогом !!!

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index must be within the limits of dynamic array.");


                return _dynamicArray[index];

            }
            set
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

                _dynamicArray[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            int indexOfFirstOccurrence = 0;

            foreach (var element in _dynamicArray)
            {
                if (element.Equals(item))
                {
                    return indexOfFirstOccurrence;
                }

                indexOfFirstOccurrence++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index >= _count || index < 0)
                throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

            for (int i = index; i < _count-1; i++)
            {
                _dynamicArray[i] = _dynamicArray[i + 1];
            }

            _count--;
        }

        public void Add(T item)
        {

            if (_count == _capacity)
            {
                T[] tempArray = new T[_capacity *= 2];
                _dynamicArray.CopyTo(tempArray, 0);

                _dynamicArray = tempArray;
            }
            _dynamicArray[_count] = item;
            _count++;

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            int indexOfItem = IndexOf(item);

            if (indexOfItem < 0)
            { 
                return false; 
            }

            RemoveAt(indexOfItem);

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dynamicArray.Take(_count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        void CopyListToArray(List<T> list)
        {
            int index = 0;

            if (list.Count == Capacity)
            {
                foreach (var item in list)
                {
                    _dynamicArray[index] = item;
                    index++;
                    _count++;
                }
            }
        }
    }
}
