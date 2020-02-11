using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class RoundEnumerator<T> : IEnumerator<T>
    {

        IList<T> _myList;

        int _index = -1;

        public RoundEnumerator(IList<T> myList)
        {
            _myList = myList;
        }

        public T Current => _myList.ElementAt(_index);

        object IEnumerator.Current => Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            int length = _myList.Count;

            if (_index == length - 1)
            {
                _index = -1;
            }
            else if (_index == length)
            {
                _index = 0;
            }

            if (_index < length - 1)
            {
                _index++;
            }

            return (length != 1);
        }

        public void Reset()
        {
            _index = -1;
        }
    }

}
