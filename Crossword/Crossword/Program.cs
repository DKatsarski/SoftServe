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




        }
    }
}
