using Crossword.Constants;
using Crossword.Data;
using Crossword.Generators;
using Crossword.Operators;
using Crossword.Verificators;
using System;
using System.Collections.Generic;

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

            crosswordGenerator.GenerateCrossword();

         

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
