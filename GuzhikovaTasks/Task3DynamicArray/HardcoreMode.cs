using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class HardcoreMode<T> : DynamicArray<T>
    {
        public HardcoreMode() : base()
        { }

        public HardcoreMode(int capacity) : base(capacity)
        { }

        public HardcoreMode(IEnumerable<T> collection) : base(collection)
        { }
        public override T this[int index]
        {
            get
            {
                if (index < 0 && index >= (-Count))
                {
                    index += Count;
                }

                return base[index];

            }
            set
            {
                if (index < 0 && index >= (-Count))
                {
                    index += Count;
                }

                dynamicArray[index] = value;
            }
        }       

        public override int Capacity => base.Capacity;
    }
}
