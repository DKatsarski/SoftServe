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


            string[,] crossword = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];

            var crosswordGenerator = new CrosswordGenerator(crossword, wordsOperator);

            crosswordGenerator.GenerateFrame();

          
            painter.PaintMatrix(crossword, 0, 0);

            var randomLetter = string.Empty;
            var colFromMatrix = string.Empty;
            var rowFromMatrix = string.Empty;
            var listFromSpecificPattern = new List<string>();
            var frameOfAPotentialWord = string.Empty;
            var colOutsideRange = 1;
            var indexCounter = 0;
            var adaptatedIndex = 0;

            for (int row = 1; row < crossword.GetLength(0); row++)
            {
                for (int col = colOutsideRange; col < crossword.GetLength(1); col++)
                {
                    colFromMatrix = arrayOperator.ExtractColFromMatrix(crossword, col);
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


                        crossword = matrixWriter.WriteOnCol(crossword, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(crossword, col, adaptatedIndex);

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

                        crossword = matrixWriter.WriteOnCol(crossword, randomWord, adaptatedIndex, col);
                        indexCounter = 0;

                        Console.Clear();
                        painter.PaintMatrix(crossword, col, adaptatedIndex);

                        break;
                    }
                }

                //row begins here

                frameOfAPotentialWord = string.Empty;
                rowFromMatrix = arrayOperator.ExtractRowFromMatrix(crossword, row);
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

                    crossword = matrixWriter.WriteOnRow(crossword, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(crossword, row, adaptatedIndex);

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



                    crossword = matrixWriter.WriteOnRow(crossword, randomWord, row, adaptatedIndex);
                    indexCounter = 0;
                    colOutsideRange++;

                    Console.Clear();
                    painter.PaintMatrix(crossword, row, adaptatedIndex);

                    continue;
                }
            }

            painter.ListAllTheWords(wordsOperator);

            Console.ReadLine();
            Console.Clear();

            //painter.PaintMatrixWithSymbol(testArray, '@');


            var listOfLetters = new List<char>();
            Console.Clear();
            painter.PaintMatrixWithSymbol(crossword, '2');
            painter.ListAllTheWords(wordsOperator);
            Console.ReadLine();
            //while (Console.ReadKey().Key != ConsoleKey.Escape)
            //{
            //    Console.WriteLine("Choose a letter: ");
            //    var suggestedLetter = Console.ReadKey().KeyChar;
            //    listOfLetters.Add(suggestedLetter);
            //    Console.ReadLine();
            //    Console.Clear();
            //    painter.PaintMatrixWithSymbol(testArray, '2');
            //    Console.ReadLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine("Press ESC to end crossword");


            //}
        }


    }
}
