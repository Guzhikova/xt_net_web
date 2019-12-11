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
            dynamicArray = new T[_capacity];
        }

        public DynamicArray(int capacity)
        {
            _capacity = capacity;
            dynamicArray = new T[_capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            _capacity = collection.Count();
            dynamicArray = new T[_capacity];

            CopyListToArray(collection);
        }

        protected T[] dynamicArray;
        private int _count = 0;

        private int _capacity = 8;

        public virtual int Capacity
        {
            get { return _capacity; }
        }


        // !!! В пункте 3.3.8 нужно было создать свойство Length. В моем случае свойство Count является его аналогом !!!

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public virtual T this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index must be within the limits of dynamic array.");

                return dynamicArray[index];

            }
            set
            {
                if (index >= _count || index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

                dynamicArray[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            int indexOfFirstOccurrence = 0;

            foreach (var element in dynamicArray)
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
            if (index >= _count || index < 0)
                throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

            if (_count == _capacity)
            {
                IncreaseCapacity();
            }

            for (int i = _count - 1; i > index; i--)
            {
                dynamicArray[i] = dynamicArray[i - 1];
            }

            dynamicArray[index] = item;
            _count++;
        }

        public void RemoveAt(int index)
        {
            if (index >= _count || index < 0)
                throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

            for (int i = index; i < _count - 1; i++)
            {
                dynamicArray[i] = dynamicArray[i + 1];
            }

            _count--;
        }

        public void Add(T item)
        {

            if (_count == _capacity)
            {
                IncreaseCapacity();
            }
            dynamicArray[_count] = item;
            _count++;

        }

        public void Clear()
        {
            Array.Clear(dynamicArray, 0, _count - 1);
            _count = 0;
        }

        public bool Contains(T item)
        {
            return (IndexOf(item) < 0) ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < _count; i++)
            {
                array.SetValue(dynamicArray[i], arrayIndex++);
            }
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

        public virtual IEnumerator<T> GetEnumerator()
        {
            return dynamicArray.Take(_count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int sumCount = _count + collection.Count();

            int multiplier = MultiplierForNewCapacity(_capacity, sumCount);

            IncreaseCapacity(multiplier);

            CopyListToArray(collection, _count);

        }

        public void ShowParameters()
        {
            Console.WriteLine($"Ёмкость = {Capacity}. Количество элементов (длина) = {Count}.");
        }

        public void ShowElements()
        {
            Console.Write($"Элементы массива: ");

            foreach (var item in this)
            {
                Console.Write($" {item} ");                
            }

            Console.WriteLine();
        }

        public void Show()
        {
            ShowParameters();
            ShowElements();
        }
        void CopyListToArray(IEnumerable<T> collection, int index = 0)
        {

            foreach (var item in collection)
            {
                dynamicArray[index] = item;
                index++;
                _count++;
            }

        }

        void IncreaseCapacity(int multiplier = 2)
        {
            T[] tempArray = new T[_capacity *= multiplier];

            dynamicArray.CopyTo(tempArray, 0);

            dynamicArray = tempArray;
        }

        int MultiplierForNewCapacity(int currentCapacity, int sumElementsCount)
        {
            int multiplier = 1;

            while (currentCapacity < sumElementsCount)
            {
                multiplier *= 2;
                currentCapacity *= multiplier;
            }

            return multiplier;
        }
    }
}
