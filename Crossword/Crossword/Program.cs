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


            int randomNumber = myRandomWords.Next(0, englishWords.Count - 1);

            var randomWord = englishWords[randomNumber];


            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[30, 30];

            for (int row = 0; row < 1; row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    
                }
            }

            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[i, 0] = randomWord[i].ToString();

                }

            }

            randomNumber = myRandomWords.Next(0, englishWords.Count - 1);
            randomWord = englishWords[randomNumber];


            while (testArray[0, 0] != randomWord[0].ToString())
            {
                randomNumber = myRandomWords.Next(0, englishWords.Count - 1);

                randomWord = englishWords[randomNumber];
            }

            for (int i = 0; i < testArray.GetLength(1); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[0, i] = randomWord[i].ToString();

                }

            }


            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    Console.Write("{0} ",
                    testArray[row, col]);
                }
                Console.WriteLine();
            }
           
        }
    }
}
