using Crossword.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Generators
{
    public class WordsExplorerFieldGenerator
    {
        private string[,] wordsExplorerField;
        private RandomGenerator randomGenerator;

        public WordsExplorerFieldGenerator()
        {
            this.randomGenerator = new RandomGenerator();
            this.wordsExplorerField = new string[GlobalConstants.MatrixSize, GlobalConstants.MatrixSize];
        }

        public string[,] GenerateField(string[] alphabet)
        {
            for (int row = 0; row < GlobalConstants.MatrixSize; row++)
            {
                for (int col = 0; col < GlobalConstants.MatrixSize; col++)
                {
                    this.wordsExplorerField[row, col] = randomGenerator.GenerateRandomLetter(alphabet);
                }
            }

            return this.wordsExplorerField;
        }
    }
}
