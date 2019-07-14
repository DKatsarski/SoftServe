using Crossword.Data;
using Crossword.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class CrosswordSolver
    {
        private Painter painter;
        private ScoreKeeper scoreKeeper;

        public CrosswordSolver()
        {
            this.painter = new Painter();
            this.scoreKeeper = new ScoreKeeper();
        }

        public void SolveCrossword(string[,] crossword, WordsOperator wordsOperator)
        {
            var justAnElement = "@";
            var guessedLetters = new List<string>() { justAnElement };

            painter.ListWordsOnlyWithHints(wordsOperator, guessedLetters);
            Console.WriteLine("Suggest Letter or Press ESC to exit:                         Wrong guesses: 0");
            var escapeButton = "\u001b";
            while (true)
            {


                var guessedLetter = Console.ReadKey()
                .KeyChar
                .ToString().ToLower();

                if (guessedLetter == escapeButton)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                                 Thanks for playing!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    break;
                }

                guessedLetters.Add(guessedLetter);
                Console.Clear();
                painter.RevealLetter(crossword, guessedLetters);


                painter.ListWordsOnlyWithHints(wordsOperator, guessedLetters);
                Console.Write("Suggest Letter or Press ESC to exit:                         Number of Tries: {0}", Counter.ReturnWrongAnswers());
                Console.WriteLine();

                if (painter.ShowEndScreen(wordsOperator, guessedLetters))
                {
                    break;
                }
            }

            //Console.WriteLine("Write your name: ");
            //Console.WriteLine();
            //Console.WriteLine();
            //var names = Console.ReadLine();
            //var score = (wordsOperator.CollectedWordsFromCrossword.Count * 1000) / Counter.CountTries();

            // scoreKeeper.RegisterAccount(names, score);
        }

    }
}
