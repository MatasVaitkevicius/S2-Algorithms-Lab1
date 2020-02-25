using System;
using System.Collections.Generic;
using System.IO;

namespace SelectionSortArray
{
    class Program
    {
        private static readonly GenerateArray RandomArray = new GenerateArray("LinkedListArray.txt");
        static void Main(string[] args)
        {
            int dataCount;
            Console.WriteLine("Enter how many data you want");
            dataCount = 20; //Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("------------------------------");
            RandomArray.GenerateRandomDataText(dataCount);
            RandomArray.PrintDataText();
            RandomArray.WriteToFileDataText();
            //WriteDataToFile(fileName,RandomArray.linkedList);
            //SelectionSortArray(dataCount);
            Console.ReadKey();
        }

        private static void WriteDataToFile(string fileName, LinkedList<ListItem> listItems)
        {
            using var writer = new StreamWriter(fileName, false);
            foreach (var listItem in listItems)
            {
                writer.WriteLine(listItem.fiveSymbols + listItem.number);
            }
        }

        //private static void SelectionSortArray(int dataCount)
        //{
        //    var smallest = 0;
        //    Console.WriteLine("------------------------------");
        //    //RandomArray.PrintData();
        //    Console.WriteLine("------------------------------");
        //    //The algorithm builds the sorted list from the left.
        //    //1. For each item in the array...
        //    for (int i = 0; i < dataCount - 1; i++)
        //    {
        //        //2. ...assume the first item is the smallest value
        //        smallest = i;
        //        //3. Cycle through the rest of the array
        //        for (int j = i + 1; j < dataCount; j++)
        //        {
        //            //4. If any of the remaining values are smaller, find the smallest of these
        //            if (RandomArray.getNumber(j) < RandomArray.getNumber(smallest))
        //            {
        //                smallest = j;
        //            }
        //        }

        //        var temporary = RandomArray.getNumber(smallest);
        //        RandomArray.setNumber(smallest, RandomArray.getNumber(i));
        //        RandomArray.setNumber(i, temporary);
        //    }

        //    //RandomArray.PrintData();
        //    Console.ReadKey();
        //}
    }
}
