using Crossword.Operators;

namespace Crossword
{
    public class MatrixWriter
    {
        private int numberOfWord;
        private WordsOperator wordsCounter;
        
        public MatrixWriter(WordsOperator wordsCounter)
        {
            this.wordsCounter = wordsCounter;
        }

        public string[,] WriteOnRow(string[,] matrix, string word, int row, int indexToStartFrom)
        {
            if (word.Length >= matrix.GetLength(1) - (indexToStartFrom))
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
                    if (i == 0)
                    {

                        this.numberOfWord = this.wordsCounter.CollectedWordsFromCrossword.Count - 1;

                        adaptedIndexArray[row, indexToStartFrom + i] = (this.numberOfWord.ToString() + word[i]).ToString();

                    }
                    else
                    {
                        adaptedIndexArray[row, indexToStartFrom + i] = word[i].ToString();

                    }
                }
                matrix = adaptedIndexArray;
            }
            else
            {

                for (int i = 0; i < word.Length; i++)
                {
                    if (i == 0)
                    {
                        this.numberOfWord = this.wordsCounter.CollectedWordsFromCrossword.Count - 1;

                        matrix[row, indexToStartFrom + i] = (this.numberOfWord.ToString() + word[i]).ToString();
                    }
                    else
                    {
                        matrix[row, indexToStartFrom + i] = word[i].ToString();
                    }
                }
            }

            return matrix;


        }

        public string[,] WriteOnCol(string[,] matrix, string word, int indexToStartFrom, int col)
        {
            if (word.Length >= matrix.GetLength(0) - (indexToStartFrom))
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
                    if (i == 0)
                    {
                        this.numberOfWord = this.wordsCounter.CollectedWordsFromCrossword.Count - 1;

                        adaptedIndexArray[indexToStartFrom + i, col] = (this.numberOfWord.ToString() + word[i]).ToString();
                    }
                    else
                    {
                        adaptedIndexArray[indexToStartFrom + i, col] = word[i].ToString();
                    }

                }

                matrix = adaptedIndexArray;
            }
            else
            {

                for (int i = 0; i < word.Length; i++)
                {
                    if (i == 0)
                    {
                        this.numberOfWord = this.wordsCounter.CollectedWordsFromCrossword.Count - 1;

                        matrix[indexToStartFrom + i, col] = (this.numberOfWord.ToString() + word[i]).ToString();
                    }
                    else
                    {
                        matrix[indexToStartFrom + i, col] = word[i].ToString();
                    }
                }
            }

            return matrix;
        }
    }
}
