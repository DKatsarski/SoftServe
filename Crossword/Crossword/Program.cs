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
            IWords englishDictionary = new EnglishWordsDictionary();

            var englishWords = englishDictionary.GetWords;

            Random myRandomWords = new Random();

            var listOfRandomWords = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                int randomNumber = myRandomWords.Next(0, englishWords.Count - 1);

                var randomWord = englishWords[randomNumber];

                listOfRandomWords.Add(randomWord);
            }


            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            Console.WriteLine(alphabet.Length);

        }
    }
}
