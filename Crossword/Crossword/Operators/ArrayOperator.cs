﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Generators
{
    public class ArrayOperator
    {
        private StringBuilder sb;

        public ArrayOperator()
        {
            this.sb = new StringBuilder();
        }

        public string GetSubStringOfTheRowOfMatrix(string[,] matrix, int row, int col)
        {
            sb.Clear();
            for (int currentIndex = 0; currentIndex <= col; currentIndex++)
            {
                sb.Append(matrix[row, (currentIndex)]);
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
    }
}