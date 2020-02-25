using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionSortArray
{
    class ListItem
    {
        public string fiveSymbols { get; set; }
        public float number { get; set; }

        public ListItem()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < 5; i++)
            {
                stringBuilder.Append(Convert.ToChar(random.Next(33, 127)));
            }
            fiveSymbols = stringBuilder.ToString();
            number = (float)random.NextDouble();
        }
    }
}
