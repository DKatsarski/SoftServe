using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class MatrixWriter
    {
        public string[,] WriteOnRow(string[,] matrix, string word, int row, int indexToStartFrom)
        {
            if (word.Length >= matrix.GetLength(1) - (indexToStartFrom + 1))
            {
                var adaptedIndexArray = new string[(matrix.GetLength(1) + word.Length + indexToStartFrom + 1), (matrix.GetLength(1) + word.Length + indexToStartFrom + 1)];

                for (int rowOfMatrix = 0; rowOfMatrix < matrix.GetLength(0); rowOfMatrix++)
                {
                    for (int colOfMatrix = 0; colOfMatrix < matrix.GetLength(1); colOfMatrix++)
                    {
                        adaptedIndexArray[rowOfMatrix, colOfMatrix] = matrix[rowOfMatrix, colOfMatrix];
                    }
                }

                for (int i = 0; i < word.Length; i++)
                {
                    adaptedIndexArray[row, indexToStartFrom + i] = word[i].ToString();
                }
                matrix = adaptedIndexArray;
            }
            else
            {

                for (int i = 0; i < word.Length; i++)
                {
                    matrix[row, indexToStartFrom + i] = word[i].ToString();
                }
            }

            return matrix;


        }

        public string[,] WriteOnCol(string[,] matrix, string word, int indexToStartFrom, int col)
        {
            if (word.Length >= matrix.GetLength(0) - (indexToStartFrom + 1))
            {
                var adaptedIndexArray = new string[(matrix.GetLength(0) + word.Length + indexToStartFrom + 1), (matrix.GetLength(0) + word.Length + indexToStartFrom + 1)];

                for (int rowOfMatrix = 0; rowOfMatrix < matrix.GetLength(0); rowOfMatrix++)
                {
                    for (int colOfMatrix = 0; colOfMatrix < matrix.GetLength(1); colOfMatrix++)
                    {
                        adaptedIndexArray[rowOfMatrix, colOfMatrix] = matrix[rowOfMatrix, colOfMatrix];
                    }
                }

                for (int i = 0; i < word.Length; i++)
                {
                    adaptedIndexArray[indexToStartFrom + i, col] = word[i].ToString();
                }
                matrix = adaptedIndexArray;
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    matrix[indexToStartFrom + i, col] = word[i].ToString();
                }
            }

            return matrix;
        }
    }
}
