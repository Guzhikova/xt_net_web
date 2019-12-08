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


        //      public int Length { get => Count; }

        public int Count => _count;


        //public int Count
        //{ 
        //    get {
        //        for (int i = 0; i < _dynamicArray.Length; i++)
        //        {
        //            if(_dynamicArray[i].)

        //        }
        //        return _count; 
        //    }
        ////    set { _count = value; }
        //}


        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index]
        {
            get
            {
                if (index >= this.Count && index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

                return _dynamicArray[index];

            }
            set
            {
                if (index >= this.Count && index < 0)
                    throw new ArgumentOutOfRangeException("Error! The index should be within the limits of dynamic array");

                _dynamicArray[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.ilist?view=netcore-2.1

            if (_count == _capacity)
            {
                T[] tempArray = new T[_capacity *= 2];
                
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
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            // https://qa-help.ru/questions/c-ienumerable-stackoverflowexception-avltree
           /* IEnumerator<T> ie = */GetEnumerator();

            //foreach (var item in this)
            //{
            //    yield return item;
            //}

            for (int i = 0; i < _dynamicArray.Length; i++)
            {
                yield return _dynamicArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dynamicArray.GetEnumerator();
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
