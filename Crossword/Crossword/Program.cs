using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Data;
using Crossword.Generators;

namespace Crossword
{
    class Program
    {
        static void Main()
        {
            IWords englishDictionary = new EnglishWordsDictionary();

            var wordsOperator = new WordsOperator(englishDictionary);
            var randomWord = wordsOperator.GenerateRandomWord();

            string[] englishAlphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[30, 30];




            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[i, 0] = randomWord[i].ToString();

                }

            }

            randomWord = wordsOperator.GenerateRandomWord();

            while (testArray[0, 0] != randomWord[0].ToString())
            {
                randomWord = wordsOperator.GenerateRandomWord();

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

            //TODO: Two for loops with a while loop inside to check if the words exists. If it exists, then save letter. 

        }
    }
}
