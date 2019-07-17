using Crossword.Constants;
using Crossword.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Crossword
{
    public class Painter
    {
        private List<int[]> coordinates;
        private ArrayOperator arrayOperator;

        public Painter()
        {
            this.coordinates = new List<int[]>();
            this.arrayOperator = new ArrayOperator();
        }
        public void PaintWordsExplorer(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public void RevealWord(string[,] fieldOfCodedWords, List<string> guessedWords)
        {
            Console.Clear();
            var lineInArray = string.Empty;
            int startIndex = 0;

            for (int row = 0; row < fieldOfCodedWords.GetLength(0); row++)
            {
                lineInArray = arrayOperator.ExtractRowFromMatrix(fieldOfCodedWords, row);

                for (int wordCount = 0; wordCount < guessedWords.Count; wordCount++)
                {
                    if (Regex.Match(lineInArray, guessedWords[wordCount]).Success)
                    {
                        startIndex = Regex.Match(lineInArray, guessedWords[wordCount]).Index;

                        for (int nextLetter = 0; nextLetter < guessedWords[wordCount].Length; nextLetter++)
                        {
                            coordinates.Add(new int[]
                            {
                                row, startIndex + nextLetter
                            });
                        }
                    }
                }
            }

            for (int col = 0; col < fieldOfCodedWords.GetLength(1); col++)
            {
                lineInArray = arrayOperator.ExtractColFromMatrix(fieldOfCodedWords, col);

                for (int wordCount = 0; wordCount < guessedWords.Count; wordCount++)
                {
                    if (Regex.Match(lineInArray, guessedWords[wordCount]).Success)
                    {
                        startIndex = Regex.Match(lineInArray, guessedWords[wordCount]).Index;

                        for (int nextLetter = 0; nextLetter < guessedWords[wordCount].Length; nextLetter++)
                        {
                            coordinates.Add(new int[]
                            {
                                startIndex + nextLetter, col
                            });
                        }
                    }
                }
            }

            var isMatch = false;

            for (int row = 0; row < fieldOfCodedWords.GetLength(0); row++)
            {
                for (int col = 0; col < fieldOfCodedWords.GetLength(1); col++)
                {
                    for (int indexOfCoordinatesOfGuessWord = 0; indexOfCoordinatesOfGuessWord < coordinates.Count; indexOfCoordinatesOfGuessWord++)
                    {
                        if (coordinates[indexOfCoordinatesOfGuessWord][0] == row && coordinates[indexOfCoordinatesOfGuessWord][1] == col)
                        {
                            isMatch = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (isMatch)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", fieldOfCodedWords[row, col]);
                        isMatch = false;
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write("{0} ", fieldOfCodedWords[row, col]);
                    }
              
                }

                Console.WriteLine();
            }

            coordinates.Clear();
        }

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

        public void ListWordsOnlyWithHints(WordsOperator wordsOperator, List<string> guessedLetters)
        {
            Console.WriteLine(wordsOperator.CollectedWordsFromCrossword.Count + " words");
            Console.WriteLine();
            var counter = 0;
            var revealedCharacters = string.Empty;
            var lastIndexOfguessedLetters = guessedLetters.Count - 1;
            bool switcher = true;
            var listOfUpdatedWords = new List<string>();

            foreach (var word in wordsOperator.CollectedWordsFromCrossword)
            {
                if (counter == 0 || counter == 1)
                {
                    revealedCharacters = Regex.Replace(word, wordsOperator.RevealGuessedLetters(guessedLetters), GlobalConstants.SpecificSymbolToReplaceNull);
                    counter++;
                    Console.WriteLine(1 + " " + word.Count() + " letters" + " " + revealedCharacters);

                }
                else
                {
                    revealedCharacters = Regex.Replace(word, wordsOperator.RevealGuessedLetters(guessedLetters), GlobalConstants.SpecificSymbolToReplaceNull);
                    Console.WriteLine(counter.ToString() + " " + word.Count() + " letters" + " " + revealedCharacters);
                    counter++;
                }
                listOfUpdatedWords.Add(revealedCharacters);
            }

            if (!listOfUpdatedWords.Any(x => x.Contains(guessedLetters[lastIndexOfguessedLetters])))
            {
                Counter.CounterOfWrongAnswers();
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
                                Console.Write("{0}", matrix[row, col][1]);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("{0}  ", matrix[row, col][2]);
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

        public bool ShowEndScreen(WordsOperator wordsOperator, List<string> guessedLetters)
        {
            var containsSymbol = true;
            var revealedCharacters = string.Empty;
            var revealedWords = new List<string>();

            foreach (var word in wordsOperator.CollectedWordsFromCrossword)
            {
                revealedCharacters = Regex.Replace(word, wordsOperator.RevealGuessedLetters(guessedLetters), GlobalConstants.SpecificSymbolToReplaceNull);
                revealedWords.Add(revealedCharacters);
            }

            foreach (var word in revealedWords)
            {
                if (word.Contains(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    return !containsSymbol;
                }
            }

            if (containsSymbol)
            {
                var score = (wordsOperator.CollectedWordsFromCrossword.Count * 1000) / Counter.ReturnWrongAnswers();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("        You've managed to solve {0} words with {1} guesses!",
                    wordsOperator.CollectedWordsFromCrossword.Count, Counter.ReturnWrongAnswers());
                Console.WriteLine();
                Console.WriteLine("        Your score is: {0}", score);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            return containsSymbol;
        }

    }
}
