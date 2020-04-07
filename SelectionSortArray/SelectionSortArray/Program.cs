using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SelectionSortOperationalMemory
{
    class Program
    {
        private static readonly GenerateLinkedList RandomLinkedList = new GenerateLinkedList();
        private static readonly GenerateArray RandomArray = new GenerateArray();

        static void Main(string[] args)
        {
            int dataCount;
            //Console.WriteLine("Enter how many data you want");
            dataCount = 5;//Convert.ToInt32(Console.ReadLine());
            BenchmarkArray(5);
            BenchmarkList(5);
            dataCount = 100;
            BenchmarkArray(100);
            BenchmarkList(100);
            dataCount = 1000;
            BenchmarkArray(1000);
            BenchmarkList(1000);
        }

        private static void WriteDataToFile(string fileName, LinkedList<ListItem> listItems)
        {
            using var writer = new StreamWriter(fileName, false);
            foreach (var listItem in listItems)
            {
                writer.WriteLine(listItem.fourSymbols + listItem.number);
            }
        }

        private static void SelectionSortArray(int dataCount)
        {
            //The algorithm builds the sorted list from the left.
            //1. For each item in the array...
            for (int i = 0; i < RandomArray.array.Length - 1; i++)
            {
                //2. ...assume the first item is the smallest value
                var smallest = i;
                //3. Cycle through the rest of the array
                for (int j = i + 1; j < RandomArray.array.Length; j++)
                {
                    //4. If any of the remaining values are smaller, find the smallest of these
                    if (RandomArray.array[j].fourSymbols.CompareTo(RandomArray.array[smallest].fourSymbols) < 0)
                    {
                        smallest = j;
                    }

                    if (RandomArray.array[j].fourSymbols.CompareTo(RandomArray.array[smallest].fourSymbols) == 0)
                    {
                        if (RandomArray.array[j].number < RandomArray.array[smallest].number)
                        {
                            smallest = j;
                        }
                    }
                }

                if (smallest != i)
                {
                    var temporary = RandomArray.array[i];
                    RandomArray.array[i] = RandomArray.array[smallest];
                    RandomArray.array[smallest] = temporary;
                }
            }
        }

        private static void SelectionSortLinkedList()
        {
            var currentOuter = RandomLinkedList.linkedList.First;
            while (currentOuter != null)
            {
                var minimum = currentOuter;
                var currentInner = currentOuter.Next;

                while (currentInner != null)
                {
                    if (currentInner.Value.fourSymbols.CompareTo(minimum.Value.fourSymbols) < 0)
                    {
                        minimum = currentInner;
                    }

                    if (currentInner.Value.fourSymbols.CompareTo(minimum.Value.fourSymbols) == 0)
                    {
                        if (currentInner.Value.number < minimum.Value.number)
                        {
                            minimum = currentInner;
                        }
                    }

                    currentInner = currentInner.Next;
                }

                if (!Object.ReferenceEquals(minimum, currentOuter))
                {
                    var temporary = currentOuter.Value;
                    RandomLinkedList.linkedList.Find(currentOuter.Value).Value = minimum.Value;
                    minimum.Value = temporary;
                }

                currentOuter = currentOuter.Next;
            }
        }

        static void BenchmarkArray(int dataCount)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("================UNSORTED RANDOM ARRAY===============");
            RandomArray.GenerateRandomDataText(dataCount);
           // RandomArray.PrintDataText();
            Console.ReadKey();
            Console.WriteLine("================SORTED RANDOM ARRAY===============");
            SelectionSortArray(dataCount);
            stopWatch.Stop();
            Console.WriteLine("==========================================");
            Console.WriteLine($"Time it took to sort {dataCount} items: {stopWatch.Elapsed.ToString()}");
            Console.WriteLine("");
            Console.ReadKey();
        }

        static void BenchmarkList(int dataCount)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("================UNSORTED RANDOM LINKED LIST===============");
            RandomLinkedList.GenerateRandomDataText(dataCount);
            //RandomLinkedList.PrintDataText();
            Console.ReadKey();
            Console.WriteLine("================SORTED RANDOM LINKED LIST===============");
            SelectionSortLinkedList();
            stopWatch.Stop();
            Console.WriteLine("==========================================");
            Console.WriteLine($"Time it took to sort {dataCount} items: {stopWatch.Elapsed.ToString()}");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
