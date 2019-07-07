using Crossword.Constants;
using Crossword.Data;
using Crossword.Generators;
using Crossword.Operators;
using System;

namespace Crossword
{
    class Program
    {
        static void Main()
        {
            IWords englishDictionary = new EnglishWordsDictionary();
            var wordsOperator = new WordsOperator(englishDictionary);
            var randomGenerator = new RandomGenerator();
            var painter = new Painter();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            string[,] crossword = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];


            for (int row = 0; row < crossword.GetLength(0); row++)
            {
                for (int col = 0; col < crossword.GetLength(1); col++)
                {
                    crossword[row, col] = randomGenerator.GenerateRandomLetter(englishDictionary.GetAplphabet);
                }
            }

            for (int row = 0; row < crossword.GetLength(0); row++)
            {
                for (int col = 0; col < crossword.GetLength(1); col++)
                {
                    Console.Write(crossword[row, col] + " ");
                }
                Console.WriteLine();
            }

            //var crosswordGenerator = new CrosswordGenerator(crossword, wordsOperator);
            //crosswordGenerator.GenerateFrame();
            //painter.PaintMatrix(crossword, 0, 0);
            //crosswordGenerator.GenerateCrossword();
        }
    }
}
