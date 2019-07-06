using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class CrosswordSolver
    {
        public void SolveCrossword(string[,] crossword)
        {
            var guessedLetter = Console.ReadKey()
                .KeyChar
                .ToString();
        }
    }
}
