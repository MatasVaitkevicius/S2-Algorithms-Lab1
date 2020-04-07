using System;
using System.IO;
using System.Text;

namespace SelectionSortDisc
{
    class Array : DataArray
    {
        TypeData[] data;
        public FileStream filestream { get; set; }
        public Array(string filename, int n, int seed)
        {
            data = new TypeData[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = new TypeData(RandomNumber(4, rand), RandomName(4, rand));
            }

            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(data[j].Numbers);
                        writer.Write(data[j].Symbols);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static double RandomNumber(int n, Random random)
        {
            string numstring = "";
            for (int i = 0; i < n; i++)
            {
                numstring += random.Next(1, 9).ToString();
            }
            double num2 = double.Parse(numstring);
            return num2;
        }

        static string RandomName(int size, Random random)
        {
            StringBuilder builder = new StringBuilder();
            char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 *
            random.NextDouble() + 65)));
            builder.Append(ch);
            for (int i = 1; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 *
               random.NextDouble() + 97)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public override void Swap(int index, double currentData, double previousData)
        {
            Byte[] data = new Byte[16];
            BitConverter.GetBytes(currentData).CopyTo(data, 0);
            BitConverter.GetBytes(previousData).CopyTo(data, 8);
            filestream.Seek(8 * (index - 1), SeekOrigin.Begin);
            filestream.Write(data, 0, 16);
        }

        public override void Set(int k, TypeData value)
        {
            Byte[] data = new Byte[13];
            BitConverter.GetBytes(value.Numbers).CopyTo(data, 0);
            Encoding.Default.GetBytes(value.Symbols).CopyTo(data, 9);
            filestream.Seek(13 * k, SeekOrigin.Begin);
            filestream.Write(data, 0, 13);
        }

        public override TypeData this[int index]
        {
            get
            {
                Byte[] data1 = new Byte[8];
                Byte[] data2 = new Byte[4];
                filestream.Seek(13 * index, SeekOrigin.Begin);
                filestream.Read(data1, 0, 8);
                filestream.Seek(13 * index + 9, SeekOrigin.Begin);
                filestream.Read(data2, 0, 4);
                double doubleValue = BitConverter.ToDouble(data1, 0);
                string stringValue = Encoding.Default.GetString(data2);
                return new TypeData(doubleValue, stringValue);
            }
        }
    }
}
