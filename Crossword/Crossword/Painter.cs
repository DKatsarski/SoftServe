using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class Painter
    {

        public void PaintMatrix(string[,] matrix)
        {
            int colOutsideRange = 0;
            Console.WriteLine();

            int rowInmatrix = 0;
            int lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1;
            bool isFound = false;

            while (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] == null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    colOutsideRange = i;
                    if (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] != null)
                    {
                        isFound = true;
                        break;

                    }
                }

                if (isFound)
                {
                    lastRowInMatrixWithLetterInIt = rowInmatrix;
                    break;
                }
                rowInmatrix++;

            }

            for (int row = 0; row < lastRowInMatrixWithLetterInIt; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == null)
                    {
                        Console.Write("    ");
                        continue;
                    }

                    Console.Write(" {0}  ", matrix[row, col]);
                    colOutsideRange = col;
                  
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
