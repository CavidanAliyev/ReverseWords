using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseWords.Service
{
    public class ReadAndReverseWords
    {
        public string GetStringAndReverse(string input)
        {
            return ReverseString(input);
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
