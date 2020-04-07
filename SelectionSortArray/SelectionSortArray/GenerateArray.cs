using System;

namespace SelectionSortOperationalMemory
{
    class GenerateArray
    {
        public int dataCount { get; set; }
        public ArrayItem[] array { get; set; }

        public void GenerateRandomDataText(int dataCount)
        {
            array = new ArrayItem[dataCount];
            this.dataCount = dataCount;
            //array[0] = new ArrayItem("zbcd", 134.45E-2f);
            //array[1] = new ArrayItem("agfd", 134.45E-2f);
            //array[2] = new ArrayItem("abcd", 134.45E-2f);
            //array[3] = new ArrayItem("abch", 1);
            //array[4] = new ArrayItem("abcd", 134.45E-2f);
            for (var i = 0; i < dataCount; i++)
            {
                array[i] = new ArrayItem();
            }
        }

        public void PrintDataText()
        {
            foreach (var arrayItem in array)
            {
                Console.WriteLine(arrayItem.fourSymbols + arrayItem.number);
            }
        }

    }
}
