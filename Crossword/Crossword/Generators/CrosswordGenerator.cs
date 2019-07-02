using Crossword.Operators;
using System.Collections.Generic;

namespace Crossword.Generators
{
    public class CrosswordGenerator
    {
        private string[,] crossword;
        private WordsOperator wordsOperator;
        private RandomGenerator randomGenerator;

        public CrosswordGenerator(string[,] crossword, WordsOperator wordsOperator)
        {
            this.crossword = crossword;
            this.wordsOperator = wordsOperator;
            this.randomGenerator = new RandomGenerator();
        }

        internal void GenerateFrame()
        {
            var randomWord = randomGenerator.GenerateRandomWord(wordsOperator.ListOfAllWords);

            for (int i = 0; i < crossword.GetLength(0); i++)
            {
                if (i < randomWord.Length)
                {
                    crossword[i, 0] = randomWord[i].ToString();
                }
            }

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);

            var newListFromBeginning = new List<string>();
            newListFromBeginning = wordsOperator.GetListOfAllWordsFromASpecifiedBeginning(randomWord[0].ToString());
            randomWord = randomGenerator.GenerateRandomWord(newListFromBeginning);

         
            for (int i = 0; i < crossword.GetLength(1); i++)
            {
                if (i < randomWord.Length)
                {
                    crossword[0, i] = randomWord[i].ToString();
                }
            }

            wordsOperator.CollectedWordsFromCrossword.Add(randomWord);
        }
    }
}
