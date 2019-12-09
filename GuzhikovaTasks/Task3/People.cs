using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class People<T>
    {
        List<T> _peopleList;

        public People(List<T> people)
        {
            _peopleList = people;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new RoundEnumerator<T>(_peopleList);
        }
    }
}
