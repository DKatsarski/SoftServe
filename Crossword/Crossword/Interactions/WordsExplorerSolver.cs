using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Interactions
{
    public class WordsExplorerSolver
    {
        private Painter painter;
        private List<string> guessedWords;

        public WordsExplorerSolver()
        {
            this.painter = new Painter();
            this.guessedWords = new List<string>();
        }

        public void GuessAWord(string[,] fieldOfCodedWords, List<string> listOfDecodedWords, string guessedWord)
        {
            var escapeButton = "\u001b";
            while (true)
            {

               // var guessedLetter = Console.ReadKey()
               //.KeyChar
               //.ToString().ToLower();

               // if (guessedLetter == escapeButton)
               // {
               //     Console.Clear();
               //     Console.WriteLine();
               //     Console.ForegroundColor = ConsoleColor.Cyan;
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine("                                 Thanks for playing!!!");
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();
               //     Console.WriteLine();

               //     break;
               // }

                if (listOfDecodedWords.Contains(guessedWord))
                {
                    guessedWords.Add(guessedWord);
                    this.painter.RevealWord(fieldOfCodedWords, guessedWords);
                }
                else
                {
                    Counter.CounterOfWrongAnswers();
                }

                this.painter.RevealWord(fieldOfCodedWords, guessedWords);
                painter.GuessingAWordVisualizer(listOfDecodedWords);
               
                guessedWord = Console.ReadLine();

            }

        }
    }
}
