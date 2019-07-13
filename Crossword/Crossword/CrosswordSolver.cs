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

        public CrosswordSolver()
        {
            this.painter = new Painter();
        }

        public void SolveCrossword(string[,] crossword, WordsOperator wordsOperator)
        {
            var guessedLetters = new List<string>();

            painter.ListWordsOnlyWithHints(wordsOperator);
            Console.WriteLine("Suggest Letter or Press ESC to exit:                         Number of Tries: 0");
            var escapeButton = "\u001b";
            while (true)
            {

              
                var guessedLetter = Console.ReadKey()
                .KeyChar
                .ToString();

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


                painter.ListWordsOnlyWithHints(wordsOperator);
                Console.Write("Suggest Letter or Press ESC to exit:                         Number of Tries: {0}", Counter.CountTries());
                Console.WriteLine();








            }



        }
    }
}
