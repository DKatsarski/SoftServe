﻿using System;
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
            var arrayOperator = new ArrayOperator();
            var randomGenerator = new RandomGenerator();
            var wordVerificator = new WordsVerificator();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            var randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);


            string[] englishAlphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[10, 10];

            var list = new List<string>()
            {
                "bojo",
                "tonkata",
                "paloma"
            };

            //it should "StartsWith" Substring of the specific caracters in the crossword
            Console.WriteLine(wordVerificator.ContainsWordWithSpecificBeginning(list, "paloma"));

            //logic for the existance of the word as a whole
            Console.WriteLine(wordVerificator.IsWordInList(list, "tonkta"));

            var asdfasdf = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning("do");
            var a = 3;

            while (randomWord.Substring(0, 2) != "do")
            {
               
                    randomWord = asdfasdf[a];

                
                a++;
            }
            Console.WriteLine(randomWord);

            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[i, 0] = randomWord[i].ToString();

                }

            }

            randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);

            while (testArray[0, 0] != randomWord[0].ToString())
            {
                randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);

            }

            for (int i = 0; i < testArray.GetLength(1); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[0, i] = randomWord[i].ToString();

                }
            }

            var randomLetter = string.Empty;
            //it starts from 1 because index is already filled
            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 1; col < testArray.GetLength(1); col++)
                {


                    randomLetter = randomGenerator.GenerateRandomLetter(englishAlphabet);
                }
            }


            //drawing
            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    Console.Write("{0} ",
                    testArray[row, col]);
                }
                Console.WriteLine();
            }

            //TODO: The logic should start from the first column, than from the frist row. It should check if there is a word from that string, than from row -> if there is word from that string. If there is not, than from the next substring

        }
    }
}
