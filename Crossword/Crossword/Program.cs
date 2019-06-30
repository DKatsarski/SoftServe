using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Data;
using Crossword.Operators;
using System.Text.RegularExpressions;
using Crossword.Constants;
using Crossword.Verificators;

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
            var matrixVerificator = new MatrixVerificator();
            var matrixWriter = new MatrixWriter(wordsOperator);
            var painter = new Painter();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            var randomWord = randomGenerator.GenerateRandomWord(listOfAllWords);


            string[] englishAlphabet = { "a", "b", "c", "d", "e",
                "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[,] testArray = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];


            for (int i = 0; i < testArray.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    testArray[i, 0] = randomWord[i].ToString();
                }
            }

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

            var newListFromBeginning = new List<string>();
            newListFromBeginning = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(randomWord[0].ToString());
            randomWord = randomGenerator.GenerateRandomWord(newListFromBeginning);

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

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);
            painter.PaintMatrix(testArray, 0, 0);

            var randomLetter = string.Empty;
            var colFromMatrix = string.Empty;
            var rowFromMatrix = string.Empty;
            var listFromSpecificPattern = new List<string>();
            var frameOfAPotentialWord = string.Empty;
            var colOutsideRange = 1;
            var indexCounter = 0;
            var adaptatedIndex = 0;

            for (int row = 1; row < testArray.GetLength(0); row++)
            {
                for (int col = colOutsideRange; col < testArray.GetLength(1); col++)
                {
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

                        adaptatedIndex = indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                        wordsOperator.CollectedWordsFromCrossword.Add(randomWord);


                        testArray = matrixWriter.WriteOnCol(testArray, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(testArray, col, adaptatedIndex);

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

                        adaptatedIndex = indexCounter;
                        listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                        randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                        wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

                        testArray = matrixWriter.WriteOnCol(testArray, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(testArray, col, adaptatedIndex);

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
                            continue;
                        }
                    }

                    adaptatedIndex = indexCounter;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);

                    wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

                    testArray = matrixWriter.WriteOnRow(testArray, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(testArray, row, adaptatedIndex);

                    continue;
                }
                else
                {
                    while (!wordVerificator.ContainsWordWithSpecificPositionOfCharacters(listOfAllWords, frameOfAPotentialWord))
                    {
                        if (frameOfAPotentialWord.Length > 1)
                        {
                            frameOfAPotentialWord = frameOfAPotentialWord.Substring(1);
                            indexCounter++;
                        }
                        else
                        {
                            throw new FormatException("No such word exists in the given database.");
                        }
                    }

                    adaptatedIndex = indexCounter;
                    listFromSpecificPattern = wordsOperator.GetListOfAllWordsFromASpecifiedPattern(frameOfAPotentialWord);
                    randomWord = randomGenerator.GenerateRandomWord(listFromSpecificPattern);
                    wordsOperator.CollectedWordsFromCrossword.Add(randomWord);



                    testArray = matrixWriter.WriteOnRow(testArray, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(testArray, row, adaptatedIndex);

                    continue;
                }
            }

            painter.ListAllTheWords(wordsOperator);

            Console.ReadLine();
            Console.Clear();
            painter.PaintMatrixWithSymbol(testArray, '2');
            painter.ListAllTheWords(wordsOperator);




        }


    }
}
