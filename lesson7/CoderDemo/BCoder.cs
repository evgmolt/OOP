using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderDemo
{
    internal class BCoder : ICoder
    {
        private readonly (char min, char max) rangeEngUp = ('A', 'Z');
        private readonly (char min, char max) rangeEngLo = ('a', 'z');
        private readonly (char min, char max) rangeRusUp = ('А', 'Я');
        private readonly (char min, char max) rangeRusLo = ('а', 'я');
        private readonly (char min, char max) rangeNoFound = ('0', '0');

        private static bool CharInRange(char c, (char, char) range)
        {
            return (c >= range.Item1 && c <= range.Item2);
        }

        private (char min, char max) GetRange(char c)
        {
            if (CharInRange(c, rangeEngUp)) return rangeEngUp;
            if (CharInRange(c, rangeEngLo)) return rangeEngLo;
            if (CharInRange(c, rangeRusUp)) return rangeRusUp;
            if (CharInRange(c, rangeRusLo)) return rangeRusLo;
            return rangeNoFound;
        }

        public string Decode(string context)
        {
            (char min, char max) range;
            string resultString = "";
            foreach (char c in context)
            {
                range = GetRange(c);
                if (range == rangeNoFound)
                {
                    resultString += c;
                }
                else
                {
                    resultString += Convert.ToChar(range.max - (c - range.min));
                }
            }
            return resultString;
        }

        public string Encode(string context)
        {
            (char min, char max) range;
            string resultString = "";
            foreach (char c in context)
            {
                range = GetRange(c);
                if (range == rangeNoFound)
                {
                    resultString += c;
                }
                else 
                {
                    resultString += Convert.ToChar(range.min - (c - range.max));
                }
            }
            return resultString;
        }
    }
}
