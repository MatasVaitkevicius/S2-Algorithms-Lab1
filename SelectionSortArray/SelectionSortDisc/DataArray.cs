using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionSortDisc
{
    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract TypeData this[int index] { get; }
        public abstract void Swap(int index, double currentData, double previousData);
        public abstract void Set(int k, TypeData value);

        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", this[i].ToString());
            Console.WriteLine();
        }
    }
}
