using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task3DynamicArray
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {}

        public CycledDynamicArray(int capacity) : base(capacity)
        { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        { }


        public override IEnumerator<T> GetEnumerator()
        {            
            return new Task3.RoundEnumerator<T>(dynamicArray);
        }
    }
}
