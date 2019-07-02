using Crossword.Constants;
using Crossword.Contracts;
using System.Text;

namespace Crossword.Operators
{
    public class ArrayOperator : IArrayOperator
    {
        private StringBuilder sb;
        private string[,] matrix;

        public ArrayOperator()
        {
            this.sb = new StringBuilder();
        }

        public ArrayOperator(string[,] matrix)
        {
            this.matrix = matrix;

        }


        public string[,] MatrixKeeper => this.matrix;

        public string GetSubStringOfTheRowOfMatrix(string[,] matrix, int row, int col)
        {
            sb.Clear();
            for (int currentIndex = 0; currentIndex <= col; currentIndex++)
            {
                sb.Append(matrix[row, currentIndex]);
            }

            return sb.ToString();
        }

        public string GetSubStringOfTheColOfMatrix(string[,] matrix, int row, int col)
        {
            sb.Clear();
            for (int currentIndex = 0; currentIndex <= row; currentIndex++)
            {
                sb.Append(matrix[currentIndex, col]);
            }

            return sb.ToString();
        }

        public string ExtractColFromMatrix(string[,] matrix, int col)
        {
            sb.Clear();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[i, col] != null)
                {
                    sb.Append(matrix[i, col]);
                }
                else
                {
                    sb.Append(GlobalConstants.SpecificSymbolToReplaceNull);
                }
            }

            return sb.ToString();
        }

        public string ExtractRowFromMatrix(string[,] matrix, int row)
        {
            sb.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[row, i] != null)
                {
                    sb.Append(matrix[row, i]);
                }
                else
                {
                    sb.Append(GlobalConstants.SpecificSymbolToReplaceNull);
                }
            }

            return sb.ToString();
        }
    }
}
