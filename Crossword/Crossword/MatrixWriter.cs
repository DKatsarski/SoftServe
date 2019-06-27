using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class MatrixWriter
    {
        private int row;
        private int col;
        private List<string> matrix;
        public MatrixWriter(List<string> matrix, int row, int col)
        {
            this.row = row;
            this.col = col;
            this.matrix = matrix;
        }
        public void WriteOnRow(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {

            }
        }

        public void WriteOnCol(string word)
        {

        }
    }
}
