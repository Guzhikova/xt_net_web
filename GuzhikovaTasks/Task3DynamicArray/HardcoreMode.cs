using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3DynamicArray
{
    class HardcoreMode<T> : DynamicArray<T>, ICloneable
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

        public object Clone()
        {
            T[] newArray = new T[Capacity];
            newArray = dynamicArray;

            return new HardcoreMode<T>
            {
                Capacity = this.Capacity,
                Count = this.Count,
                dynamicArray = newArray
            };
        }

        public T[] ToArray()
        {
            return dynamicArray;
        }

        public void CutCapacity(int capacity)
        {
            T[] tempArray = new T[capacity];

            Array.Copy(dynamicArray, 0, tempArray, 0, capacity);

            dynamicArray = tempArray;

            Capacity = capacity;
            Count = dynamicArray.Length;
        }

    }
}
