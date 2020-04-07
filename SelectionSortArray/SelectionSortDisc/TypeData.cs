using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionSortDisc
{
    class TypeData
    {
        public double Numbers { get; set; }
        public string Symbols { get; set; }

        public TypeData()
        {

        }

        public TypeData(double numbers, string name)
        {
            Symbols = name;
            Numbers = numbers;
        }

        public override string ToString()
        {
            return String.Format(Numbers + Symbols);
        }

        public static bool operator <=(TypeData lhs, TypeData rhs)
        {
            if (lhs.Numbers < rhs.Numbers)
            {
                return true;
            }

            if (lhs.Numbers == rhs.Numbers && lhs.Symbols.CompareTo(rhs.Symbols) <= 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator >=(TypeData lhs, TypeData rhs)
        {
            if (lhs.Numbers > rhs.Numbers)
            {
                return true;
            }
            if (lhs.Numbers == rhs.Numbers && lhs.Symbols.CompareTo(rhs.Symbols) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
