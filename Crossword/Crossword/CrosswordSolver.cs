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

        public void SolveCrossword(string[,] crossword)
        {
            var guessedLetters = new List<string>();

            var escapeButton = "\u001b";
            while (true)
            {
                var guessedLetter = Console.ReadKey()
                .KeyChar
                .ToString();

                if (guessedLetter == escapeButton)
                {
                    Console.WriteLine("Thanks for playing!!!");
                    break;
                }

                guessedLetters.Add(guessedLetter);

                painter.RevealLetter(crossword, guessedLetters);









         
            }
            


        }
    }
}
