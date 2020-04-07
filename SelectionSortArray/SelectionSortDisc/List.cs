using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SelectionSortDisc
{
    class List : DataList
    {
        public FileStream filestream { get; set; }
        int prevNode;
        int currentNode;
        int nextNode;

        public List(string filename, int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    writer.Write(4);
                    for (int j = 0; j < length; j++)
                    {
                        TypeData typeData = new TypeData(RandomNumber(4, rand), RandomName(4, rand));
                        Byte[] data = new Byte[13];
                        BitConverter.GetBytes(typeData.Numbers).CopyTo(data, 0);
                        Encoding.Default.GetBytes(typeData.Symbols).CopyTo(data, 9);
                        writer.Write(data, 0, 13);
                        writer.Write((j + 1) * 17);
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

        public override void Swap(double currentData, double previousData)
        {
            Byte[] data;
            filestream.Seek(prevNode, SeekOrigin.Begin);
            data = BitConverter.GetBytes(currentData);
            filestream.Write(data, 0, 8);
            filestream.Seek(currentNode, SeekOrigin.Begin);
            data = BitConverter.GetBytes(previousData);
            filestream.Write(data, 0, 8);
        }

        public override TypeData Head()
        {
            Byte[] data1 = new Byte[8];
            Byte[] data2 = new Byte[4];
            Byte[] data3 = new Byte[4];
            filestream.Seek(0, SeekOrigin.Begin);
            filestream.Read(data1, 0, 4);

            currentNode = BitConverter.ToInt32(data1, 0);
            prevNode = -1;

            filestream.Seek(currentNode, SeekOrigin.Begin);
            filestream.Read(data1, 0, 8);

            filestream.Seek(13, SeekOrigin.Begin);
            filestream.Read(data2, 0, 4);

            filestream.Seek(17, SeekOrigin.Begin);
            filestream.Read(data3, 0, 4);

            nextNode = BitConverter.ToInt32(data3, 0);
            double doubleValue = BitConverter.ToDouble(data1, 0);
            string stringValue = Encoding.Default.GetString(data2);
            TypeData data = new TypeData(doubleValue, stringValue);

            return data;
        }

        public override void SetPosition(int k)
        {
            if (k == 0)
            {
                Head();
            }
            nextNode = (k) * 17;
            currentNode = nextNode - 17;
        }

        public override TypeData Next()
        {
            Byte[] data1 = new Byte[8];
            Byte[] data2 = new Byte[4];
            Byte[] data3 = new Byte[4];
            filestream.Seek(nextNode + 4, SeekOrigin.Begin);

            filestream.Read(data1, 0, 8);

            filestream.Seek(nextNode + 13, SeekOrigin.Begin);
            filestream.Read(data2, 0, 4);

            filestream.Seek(nextNode + 17, SeekOrigin.Begin);
            filestream.Read(data3, 0, 4);


            prevNode = currentNode;
            currentNode = nextNode;
            nextNode = BitConverter.ToInt32(data3, 0);
            double doubleValue = BitConverter.ToDouble(data1, 0);
            string stringValue = Encoding.Default.GetString(data2);
            TypeData data = new TypeData(doubleValue, stringValue);

            return data;
        }

        public override void SetValue(TypeData obj, int k)
        {
            if (k < length)
            {
                Byte[] objData = new Byte[13];
                BitConverter.GetBytes(obj.Numbers).CopyTo(objData, 0);
                Encoding.Default.GetBytes(obj.Symbols).CopyTo(objData, 9);

                if (k == 0)
                {
                    filestream.Seek(4, SeekOrigin.Begin);
                    filestream.Write(objData, 0, 13);
                }
                else
                {
                    filestream.Seek(k * 17 + 4, SeekOrigin.Begin);
                    filestream.Write(objData, 0, 13);
                }
            }
        }
    }
}
