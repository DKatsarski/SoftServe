using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class Painter
    {

        public void PaintMatrix(string[,] matrix, int intRowOrCol, int indexToStartFrom)
        {
            //Console.Write(" 1");
            Console.WriteLine();
            int wordCounter = 1;
            int colOutsideRange = 0;
            int rowInmatrix = 0;
            int lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1;
            bool isFound = false;

            // cleaningn the matrix from unnecessary lines
            while (matrix[matrix.GetLength(0) - 1 - rowInmatrix, colOutsideRange] == null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (matrix[matrix.GetLength(0) - 1 - rowInmatrix, i] != null)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1 - rowInmatrix;
                    break;
                }
                rowInmatrix++;
                lastRowInMatrixWithLetterInIt = matrix.GetLength(0) - 1 - rowInmatrix;
            }

            for (int row = 0; row < lastRowInMatrixWithLetterInIt; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != null && matrix[row, col].Length > 1)
                    {

                        if (matrix[row, col].Length == 2)
                        {
                            Console.Write(" {0}{1}  ", matrix[row, col][0], matrix[row, col][1]);
                        }
                        else
                        {
                            Console.Write("{0}{1}{2}  ", matrix[row, col][0], matrix[row, col][1], matrix[row, col][2]);
                        }
                    }
                    else
                    {
                        if (matrix[row, col] == null)
                        {
                            Console.Write("     ");
                            indexToStartFrom++;
                        }
                        else
                        {
                            Console.Write("  {0}  ", matrix[row, col]);

                        }
                    }
                  


                    colOutsideRange = col;
                }

                //row

                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}
