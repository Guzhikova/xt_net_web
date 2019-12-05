using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class PeopleEnumeration<T> : IEnumerable<T>, IEnumerator<T>
    {

        List<T> _myList;
        public List<T> MyList { get; set; }

        int _index = -1;

        public PeopleEnumeration(List<T> myList)
        {
            _myList = myList;
        }

        public T Current => _myList.ElementAt(_index);

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {

            if (_myList.Count == 1)
            {
                return false;
            }
            else if (_index == _myList.Count - 1)
            {
                _index = -1;
            }
            else if (_index == _myList.Count)
            {
                _index = 0; 
            }
            
            if (_index < _myList.Count - 1)
                _index++;

            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
