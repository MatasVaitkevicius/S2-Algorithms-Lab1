using System;
using System.Text;

namespace SelectionSortOperationalMemory
{
    class ListItem
    {
        public string fourSymbols { get; set; }
        public float number { get; set; }

        public ListItem()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < 4; i++)
            {
                stringBuilder.Append(Convert.ToChar(random.Next(33, 127)));
            }
            fourSymbols = stringBuilder.ToString();
            number = (float)random.NextDouble();
        }

        public ListItem(string symbols, float chosenNumber)
        {
            fourSymbols = symbols;
            number = chosenNumber;
        }
    }
}
