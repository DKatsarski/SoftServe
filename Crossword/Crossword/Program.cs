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
            var englishWords = englishDictionary.GetWords;

            Random myRandomWords = new Random();

            int randomNumber = myRandomWords.Next(0, englishWords.Count - 1);

            var randomWord = englishWords[randomNumber];

            Console.WriteLine(randomWord);
            
        }
    }
}
