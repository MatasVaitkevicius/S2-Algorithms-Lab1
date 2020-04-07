using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSortDisc
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int) DateTime.Now.Ticks & 0x0000FFFF;
            int size = 12;

            TestFileArrayAndList(seed, size);
            Benchmark(seed);
        }

        public static void Benchmark(int seed)
        {
            string filename = @"Benchmark.txt";

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("ARRAY");
                writer.WriteLine();
                writer.WriteLine(String.Format("N             RUN TIME"));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 100, BenchmarkArray(100, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 200, BenchmarkArray(200, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 400, BenchmarkArray(400, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 800, BenchmarkArray(800, seed)));
                writer.WriteLine();

                writer.WriteLine("LIST");
                writer.WriteLine();
                writer.WriteLine(String.Format("N             RUN TIME"));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 100, BenchmarkList(100, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 100, BenchmarkList(100, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 100, BenchmarkList(100, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 200, BenchmarkList(200, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 400, BenchmarkList(400, seed)));
                writer.WriteLine(String.Format("{0, -10} {1, -20}", 800, BenchmarkList(800, seed)));
            }
        }

        public static string BenchmarkArray(int n, int seed)
        {
            string filenameArray = @"dataArray.dat";

            if (File.Exists(filenameArray))
            {
                File.Delete(filenameArray);
            }

            Stopwatch stopWatch = new Stopwatch();
            string time;

            Array myarray = new Array(filenameArray, n, seed);

            using (myarray.filestream = new FileStream(filenameArray, FileMode.Open,
                FileAccess.ReadWrite))
            {
                stopWatch.Start();
                //sort
                stopWatch.Stop();
                time = stopWatch.Elapsed.ToString();
            }

            return time;
        }

        public static string BenchmarkList(int n, int seed)
        {
            string filenameArray = @"dataList.dat";

            if (File.Exists(filenameArray))
            {
                File.Delete(filenameArray);
            }

            Stopwatch stopWatch = new Stopwatch();
            string time;

            List myList = new List(filenameArray, n, seed);

            using (myList.filestream = new FileStream(filenameArray, FileMode.Open,
                FileAccess.ReadWrite))
            {
                stopWatch.Start();
                //sort
                stopWatch.Stop();
                time = stopWatch.Elapsed.ToString();
            }

            return time;
        }

        public static void TestFileArrayAndList(int seed, int n)
        {
            string filename;
            string time;
            Stopwatch stopWatch = new Stopwatch();

            filename = @"dataArray.dat";
            Array myfilearray = new Array(filename, n, seed);

            using (myfilearray.filestream = new FileStream(filename, FileMode.Open,
                FileAccess.ReadWrite))
            {
                Console.WriteLine("-----------FILE ARRAY-----------");
                Console.WriteLine("-----------UNSORTED-----------");
                myfilearray.Print(n);

                stopWatch.Start();
                //sort
                stopWatch.Stop();
                time = stopWatch.Elapsed.ToString();

                Console.WriteLine("-----------SORTED-----------");
                myfilearray.Print(n);
                Console.WriteLine(time);
            }
            filename = @"dataList.dat";
            List myfilelist = new List(filename, n, seed);
            using (myfilelist.filestream = new FileStream(filename, FileMode.Open,
                FileAccess.ReadWrite))
            {
                Console.WriteLine("-----------FILE LIST-----------");
                Console.WriteLine("-----------UNSORTED-----------");
                myfilelist.Print(n);

                stopWatch.Reset();
                stopWatch.Start(); 
                //sort
                stopWatch.Stop();
                time = stopWatch.Elapsed.ToString();

                Console.WriteLine("-----------SORTED-----------");
                myfilelist.Print(n);
                Console.WriteLine(time);
            }
        }
    }
}    