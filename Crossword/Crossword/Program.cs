using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Data;

namespace Crossword
{
    class Program
    {
        static void Main()
        {
            var englishDictionary = new EnglishWordsDictionary();
            var list = englishDictionary.GetWords;

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
