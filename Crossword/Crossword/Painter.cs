using Crossword.Constants;
using Crossword.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossword
{
    public class Painter
    {

        public void PaintMatrix(string[,] matrix, int intRowOrCol, int indexToStartFrom)
        {
            Console.WriteLine();
            Console.Write(" 1");
            int colOutsideRange = 0;
            int rowInmatrix = 0;
            int lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1;
            bool isFound = false;

            // cleaningn the matrix from unnecessary lines
            while (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] == null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[matrix.GetLength(0) - 1 - rowInmatrix, i] != null)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
                    break;
                }
                rowInmatrix++;
                lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
            }

            for (int row = 0; row < lastRowInMatrixWithLetterInIt; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != null && matrix[row, col].Length > 1)
                    {

                        if (matrix[row, col].Length == 2)
                        {
                            Console.Write(" {0}{1}  ", matrix[row, col][0], matrix[row, col][1]);
                        }
                        else
                        {
                            Console.Write("{0}{1}{2}  ", matrix[row, col][0], matrix[row, col][1], matrix[row, col][2]);
                        }
                    }
                    else
                    {
                        if (matrix[row, col] == null)
                        {
                            Console.Write("     ");
                            indexToStartFrom++;
                        }
                        else
                        {
                            if (row == 0 && col == 0)
                            {
                                Console.Write("{0}  ", matrix[row, col]);
                            }
                            else
                            {
                                Console.Write("  {0}  ", matrix[row, col]);
                            }

                        }
                    }
                    colOutsideRange = col;
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void ListAllTheWords(WordsOperator wordsOperator)
        {
            Console.WriteLine(wordsOperator.CollectedWordsFromCrossword.Count + " words");
            Console.WriteLine();
            var counter = 0;
            foreach (var word in wordsOperator.CollectedWordsFromCrossword)
            {
                if (counter == 0 || counter == 1)
                {
                    counter++;
                    Console.WriteLine(1 + " " + word.ToString());
                }
                else
                {
                    Console.WriteLine(counter.ToString() + " " + word.ToString());
                    counter++;
                }

            }
        }

        public void PaintMatrixWithSymbol(string[,] matrix, string specificSymbol)
        {
            Console.WriteLine();
            Console.Write(" 1");
            int colOutsideRange = 0;
            int rowInmatrix = 0;
            int lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1;
            bool isFound = false;

            // cleaningn the matrix from unnecessary lines
            while (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] == null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[matrix.GetLength(0) - 1 - rowInmatrix, i] != null)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
                    break;
                }
                rowInmatrix++;
                lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
            }

            for (int row = 0; row < lastRowInMatrixWithLetterInIt; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != null && matrix[row, col].Length > 1)
                    {

                        if (matrix[row, col].Length == 2)
                        {
                            Console.Write(" {0}{1}  ", matrix[row, col][0], specificSymbol);
                        }
                        else
                        {
                            Console.Write("{0}{1}{2}  ", matrix[row, col][0], matrix[row, col][1], specificSymbol);
                        }
                    }
                    else
                    {
                        if (matrix[row, col] == null)
                        {
                            Console.Write("     ");
                        }
                        else
                        {
                            if (row == 0 && col == 0)
                            {
                                Console.Write("{0}  ", specificSymbol);
                            }
                            else
                            {
                                Console.Write("  {0}  ", specificSymbol);
                            }

                        }
                    }
                    colOutsideRange = col;
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void RevealLetter(string[,] matrix, List<string> guessedLetters)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write(" 1");
            int colOutsideRange = 0;
            int rowInmatrix = 0;
            int lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1;
            bool isFound = false;

            // cleaningn the matrix from unnecessary lines
            while (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] == null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[matrix.GetLength(0) - 1 - rowInmatrix, i] != null)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
                    break;
                }
                rowInmatrix++;
                lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - rowInmatrix;
            }

            for (int row = 0; row < lastRowInMatrixWithLetterInIt; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != null && matrix[row, col].Length > 1)
                    {

                        if (guessedLetters.Any(x => matrix[row, col].Contains(x)))
                        {
                            if (matrix[row, col].Length == 2)
                            {

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" {0}", matrix[row, col][0]);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("{0}  ", matrix[row, col][1]);


                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.Write("{0}", matrix[row, col][0]);
                                Console.Write("{0}",  matrix[row, col][1]);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.Write("{0}  ",  matrix[row, col][2]);


                            }
                        }
                        else
                        {
                            Console.ResetColor();
                            if (matrix[row, col].Length == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.Write(" {0}{1}  ", matrix[row, col][0], GlobalConstants.SymbolToHideNumbersWith);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.Write("{0}{1}{2}  ", matrix[row, col][0], matrix[row, col][1], GlobalConstants.SymbolToHideNumbersWith);
                            }
                        }
                       
                    }
                    else
                    {
                        Console.ResetColor();

                        if (matrix[row, col] == null)
                        {
                            Console.Write("     ");
                        }
                        else
                        {

                            if (guessedLetters.Any(x => matrix[row, col].Contains(x)))
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                if (row == 0 && col == 0)
                                {
                                    Console.Write("{0}  ", matrix[row, col]);
                                }
                                else
                                {
                                    Console.Write("  {0}  ", matrix[row, col]);
                                }
                            }
                            else
                            {
                                Console.ResetColor();

                                if (row == 0 && col == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.Write("{0}  ", GlobalConstants.SymbolToHideNumbersWith);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.Write("  {0}  ", GlobalConstants.SymbolToHideNumbersWith);
                                }
                            }
                        }
                    }
                    colOutsideRange = col;
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }


    }
}
