using Crossword.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class ValidWordsCounter
    {
        private WordsVerificator wordsVerificator;
        private List<string> validWordsHolder;
        private StringBuilder wordToBechecked;

        public ValidWordsCounter()
        {
            this.wordsVerificator = new WordsVerificator();
            this.validWordsHolder = new List<string>();
            this.wordToBechecked = new StringBuilder();
        }

        public List<string> GetListWithDecodedWords(string[,] wordsExplorerField, List<string> listOfAllWords)
        {
            for (int allTries = 0; allTries < GlobalConstants.MatrixSize; allTries++)
            {
                for (int row = 0; row < GlobalConstants.MatrixSize; row++)
                {
                    for (int col = allTries; col < GlobalConstants.MatrixSize; col++)
                    {
                        wordToBechecked.Append(wordsExplorerField[row, col]);

                        if (wordToBechecked.ToString().Length > GlobalConstants.MinWordSize
                            && wordsVerificator.IsWordInList(listOfAllWords, wordToBechecked.ToString()))
                        {
                            this.validWordsHolder.Add(wordToBechecked.ToString());
                        }
                    }
                    wordToBechecked.Clear();

                }

                wordToBechecked.Clear();
            }

            for (int allTries = 0; allTries < GlobalConstants.MatrixSize; allTries++)
            {
                for (int row = 0; row < GlobalConstants.MatrixSize; row++)
                {
                    for (int col = allTries; col < GlobalConstants.MatrixSize; col++)
                    {
                        wordToBechecked.Append(wordsExplorerField[col, row]);
                        var a = wordToBechecked.ToString().Length;
                        if (wordToBechecked.ToString().Length > GlobalConstants.MinWordSize
                            && wordsVerificator.IsWordInList(listOfAllWords, wordToBechecked.ToString()))
                        {
                            this.validWordsHolder.Add(wordToBechecked.ToString());
                        }
                    }
                    wordToBechecked.Clear();

                }

                wordToBechecked.Clear();
            }

            return this.validWordsHolder;
        }

    }
}


