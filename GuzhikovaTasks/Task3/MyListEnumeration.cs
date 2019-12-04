﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MyListEnumeration<T> : IEnumerable<T>, IEnumerator<T>
    {

        List<T> _myList;
        public List<T> MyList { get; set; }

        public int Index { get; }
        int index = -1;

        public MyListEnumeration(List<T> myList)
        {
            _myList = myList;
        }

        public T Current => _myList.ElementAt(index);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //Что тут писать??????????????????

            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_myList.Count == 0 || _myList.Count == 1)
            {
                Console.WriteLine("false");

                Reset();
                return false;
            }
            else
            {

                if (index + 1 == _myList.Count)
                {
                    index = 1;
                }
                else if (index + 1 == _myList.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index += 2;
                }
         return true;
            }


   
        }      

        public void Reset()
        {
            index = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
