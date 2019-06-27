using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class MatrixWriter
    {
        public void WriteOnRow(string[,] matrix, string word, int row, int indexToStartFrom)
        {
            for (int i = 0; i < word.Length; i++)
            {
                matrix[row, indexToStartFrom + i] = word[i].ToString();
            }
        }

        public void WriteOnCol(string[,] matrix, string word, int indexToStartFrom, int col)
        {
            for (int i = 0; i < word.Length; i++)
            {
                matrix[indexToStartFrom + i, col] = word[i].ToString();
            }
        }
    }
}
