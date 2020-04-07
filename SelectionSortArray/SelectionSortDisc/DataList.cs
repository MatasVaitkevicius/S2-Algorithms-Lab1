using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionSortDisc
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract TypeData Head();
        public abstract TypeData Next();
        public abstract void Swap(double currentData, double previousData);
        public abstract void SetValue(TypeData obj, int k);
        public abstract void SetPosition(int k);

        public void Print(int n)
        {
            Console.Write("{0} ", Head());
            for
                (int i = 1; i < n; i++)
                Console.Write("{0} ", Next());
            Console.WriteLine();

        }
    }
}
