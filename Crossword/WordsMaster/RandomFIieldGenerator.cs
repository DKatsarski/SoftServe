using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordsMaster
{
    public class RandomFIieldGenerator
    {
        private string[,] crossword;

        public RandomFIieldGenerator(string[,] crossword)
        {
            this.crossword = crossword;
        }

        public void GenerateRandomFieldOfLetters()
        {

            //for (int row = 0; row < crossword.GetLength(0); row++)
            //{
            //    for (int col = 0; col < crossword.GetLength(1); col++)
            //    {
            //        crossword[row, col] = randomGenerator.GenerateRandomLetter(englishDictionary.GetAplphabet);
            //    }
            //}
        }
    }
}
