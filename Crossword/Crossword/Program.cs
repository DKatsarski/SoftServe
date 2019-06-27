﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Data;
using Crossword.Operators;
using System.Text.RegularExpressions;
using Crossword.Constants;

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
            var matrixWriter = new MatrixWriter();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            var randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);


            string[] englishAlphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[40, 40];

          


      
   






         
            //var asdfasdf = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning("do");
            //var a = 3;

            //while (randomWord.Substring(0, 2) != "do")
            //{

            //        randomWord = asdfasdf[a];


            //    a++;
            //}
            //Console.WriteLine(randomWord);





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

         

            //drawing
            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    Console.Write(testArray[row, col]);
                }

                Console.WriteLine();
            }

            var randomLetter = string.Empty;
            var colFromMatrix = string.Empty;
            var rowFromMatrix = string.Empty;
            var listFromSpecificPattern = new List<string>();

            var frameOfAPotentialWord = string.Empty;
            var colOutsideRange = 0;
            var indexCounter = 0;
            var adaptatedIndex = 0;

            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 1; col < testArray.GetLength(1); col++)
                {
                    colOutsideRange = col;
                    colFromMatrix = arrayOperator.ExtractColFromMatrix(testArray, col);
                    frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(colFromMatrix);

                    if (frameOfAPotentialWord == string.Empty)
                    {
                        break;
                    }

                    if (!frameOfAPotentialWord.Contains(GlobalConstants.SpecificSymbolToReplaceNull))
                    {
                        while (!wordVerificator.ContainsWordWithSpecificBeginning(listOfAllWords, frameOfAPotentialWord))
                        {
                            if (frameOfAPotentialWord.Length > 1)
                            {
                                frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                                indexCounter++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        adaptatedIndex = row + indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                        matrixWriter.WriteOnCol(testArray, randomWord, adaptatedIndex, col);
                        indexCounter = 0;
                        break;
                    }
                    else
                    {
                        while (!wordVerificator.ContainsWordWithSpecificPositionOfCharacters(listOfAllWords, frameOfAPotentialWord))
                        {
                            //potential problem with the ">1"
                            if (frameOfAPotentialWord.Length > 1)
                            {
                                frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                                indexCounter++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        adaptatedIndex = row + indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                        matrixWriter.WriteOnCol(testArray, randomWord, adaptatedIndex, col);
                        indexCounter = 0;
                        break;
                    }
                }

                //row begins here

                frameOfAPotentialWord = string.Empty;
                rowFromMatrix = arrayOperator.ExtractRowFromMatrix(testArray, row);
                frameOfAPotentialWord = wordsOperator.ExtractFrameOfAPotentialWord(rowFromMatrix);
                indexCounter = 0;

                if (frameOfAPotentialWord == string.Empty)
                {
                    break;
                }

                //fillerOfMatrix
                if (!frameOfAPotentialWord.Contains(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    while (!wordVerificator.ContainsWordWithSpecificBeginning(listOfAllWords, frameOfAPotentialWord))
                    {
                        if (frameOfAPotentialWord.Length > 1)
                        {
                            frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                            indexCounter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    adaptatedIndex = indexCounter + colOutsideRange;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                    matrixWriter.WriteOnRow(testArray, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    break;
                }
                else
                {
                    while (!wordVerificator.ContainsWordWithSpecificPositionOfCharacters(listOfAllWords, frameOfAPotentialWord))
                    {
                        //potential problem with the ">1"
                        if (frameOfAPotentialWord.Length > 1)
                        {
                            frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                            indexCounter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    adaptatedIndex = indexCounter + colOutsideRange;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                    matrixWriter.WriteOnRow(testArray, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    break;
                }
            }


            //drawing
            for (int row = 0; row < testArray.GetLength(0); row++)
            {
                for (int col = 0; col < testArray.GetLength(1); col++)
                {
                    Console.Write(testArray[row, col]);
                }

                Console.WriteLine();
            }

            //TODO: The logic should start from the first column, than from the frist row. It should check if there is a word from that string, than from row -> if there is word from that string. If there is not, than from the next substring

        }


    }
}
