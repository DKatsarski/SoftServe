using Crossword.Constants;
using Crossword.Data;
using Crossword.Generators;
using Crossword.Interactions;
using Crossword.Operators;
using System;

namespace Crossword
{
    public class Program
    {
        static void Main()
        {
            IWords englishDictionary = new EnglishWordsDictionary();
            var wordsOperator = new WordsOperator(englishDictionary);
            var randomGenerator = new RandomGenerator();
            var painter = new Painter();
            var listOfAllWords = wordsOperator.ListOfAllWords;
            painter.ChooseAGame();
            var gameOfChoice = int.Parse(Console.ReadLine());

            while (gameOfChoice != 1 || gameOfChoice != 2)
            {
                if (gameOfChoice == 1)
                {
                    string[,] crossword = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];
                    var crosswordGenerator = new CrosswordGenerator(crossword, wordsOperator);
                    crosswordGenerator.GenerateFrame();
                    painter.PaintMatrix(crossword, 0, 0);
                    crosswordGenerator.GenerateCrossword();
                    break;

                }
                else if (gameOfChoice == 2)
                {
                    var wordsExplorerFieldGenerator = new WordsExplorerFieldGenerator();
                    var validWordsCounter = new ValidWordsCounter();
                    var wordsExplorerSolver = new WordsExplorerSolver();
                    var wordsExplorerField = wordsExplorerFieldGenerator.GenerateField(englishDictionary.GetAplphabet);
                    var listOfExistingWords = validWordsCounter.GetListWithDecodedWords(wordsExplorerField, listOfAllWords);
                    painter.PaintWordsExplorer(wordsExplorerField);
                    painter.GuessingAWordVisualizer(listOfExistingWords);
                    var guessedWords = Console.ReadLine();
                    wordsExplorerSolver.GuessAWord(wordsExplorerField, listOfExistingWords, guessedWords);
                    painter.PaintWordsExplorer(wordsExplorerField);
                    break;
                }
                else
                {
                    Console.Clear();
                    painter.ChooseAGame();
                    gameOfChoice = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
