﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SelectionSortArray
{
    class GenerateLinkedList
    {
        private readonly BinaryWriter _binaryWriter;
        private readonly BinaryReader _binaryReader;
        private readonly FileStream _fileStream;
        private readonly StreamWriter _streamWriter;

        public int dataCount { get; set; }
        public LinkedList<ListItem> linkedList { get; set; }

        public GenerateLinkedList(string fileName)
        {
            //_fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            _streamWriter = new StreamWriter(fileName);
            //_binaryWriter = new BinaryWriter(_fileStream);
            //_binaryReader = new BinaryReader(_fileStream);
        }

        public void GenerateRandomDataText(int dataCount)
        {
            linkedList = new LinkedList<ListItem>();
            this.dataCount = dataCount;
            linkedList.AddLast(new ListItem("abcd", 2));
            linkedList.AddLast(new ListItem("zbcd", 2));
            linkedList.AddLast(new ListItem("cbcd", 134.45E-2f));
            linkedList.AddLast(new ListItem("abcd", 134.45E-2f));
            linkedList.AddLast(new ListItem("abcd", 2));
            linkedList.AddLast(new ListItem("abcz", 2));
            linkedList.AddLast(new ListItem("abcd", 2));
            //for (int i = 0; i < dataCount; i++)
            //{
            //    linkedList.AddLast(new ListItem());
            //}

        }

            public float getNumber(int i)
        {
            var k = i * 4;
            _binaryReader.BaseStream.Seek(k, SeekOrigin.Begin);
            return _binaryReader.ReadSingle();
        }

        public void PrintDataText()
        {
            foreach (var listItem in linkedList)
            {
                Console.WriteLine(listItem.fourSymbols + listItem.number);
            }
        }

        public void WriteToFileDataText()
        {
            using (_streamWriter)
            {
                foreach (var listItem in linkedList)
                {
                    _streamWriter.WriteLine(listItem.fourSymbols + listItem.number);
                }
            }
        }

        public void setNumber(int i, float value)
        {
            var k = i * 4;
            _binaryWriter.BaseStream.Seek(k, SeekOrigin.Begin);
            _binaryWriter.Write(value);
        }


        public void PrintDataBinary()
        {
            var i = 0;
            for (var j = 0; j < dataCount; j++)
            {
                var temp = getNumber(j);
                Console.WriteLine(temp);
                i++;
            }
        }

        public void CloseFile()
        {
            _fileStream.Close();
            _binaryWriter.Close();
            _binaryReader.Close();
        }
    }
}
