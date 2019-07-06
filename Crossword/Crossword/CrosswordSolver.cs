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
            for (int ro = 0; ro < crossword.GetLength(0); ro++)
            {
                for (int col = 0; col < crossword.GetLength(1); col++)
                {
                    Console.Write(crossword[ro, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
