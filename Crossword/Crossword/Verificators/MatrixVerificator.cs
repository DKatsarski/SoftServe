﻿namespace Crossword.Verificators
{
    public class MatrixVerificator
    {
        public bool WordWillBeOutsideOfMatrixColBoundery(string[,] matrix, string word, int currentIndex)
        {
            if (matrix.GetLength(0) <= (word.Length + currentIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WordWillBeOutsideOfMatrixRowBoundery(string[,] matrix, string word, int currentIndex)
        {
            if (matrix.GetLength(1) <= (word.Length + currentIndex))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
