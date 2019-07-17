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
        private StringBuilder wordToBecheckedOnCols;
        private StringBuilder wordToBecheckedOnRows;

        public ValidWordsCounter()
        {
            this.wordsVerificator = new WordsVerificator();
            this.validWordsHolder = new List<string>();
            this.wordToBecheckedOnCols = new StringBuilder();
            this.wordToBecheckedOnRows = new StringBuilder();
        }

        public List<string> GetListWithDecodedWords(string[,] wordsExplorerField, List<string> listOfAllWords)
        {
            for (int allTries = 0; allTries < GlobalConstants.MatrixSize; allTries++)
            {
                for (int row = 0; row < GlobalConstants.MatrixSize; row++)
                {
                    for (int col = allTries; col < GlobalConstants.MatrixSize; col++)
                    {
                        wordToBecheckedOnCols.Append(wordsExplorerField[row, col]);
                        wordToBecheckedOnRows.Append(wordsExplorerField[col, row]);

                        if (wordToBecheckedOnCols.ToString().Length > GlobalConstants.MinWordSize
                            && wordsVerificator.IsWordInList(listOfAllWords, wordToBecheckedOnCols.ToString()))
                        {
                            this.validWordsHolder.Add(wordToBecheckedOnCols.ToString());
                        }

                        if (wordToBecheckedOnRows.ToString().Length > GlobalConstants.MinWordSize
                           && wordsVerificator.IsWordInList(listOfAllWords, wordToBecheckedOnRows.ToString()))
                        {
                            this.validWordsHolder.Add(wordToBecheckedOnRows.ToString());
                        }
                    }

                    wordToBecheckedOnCols.Clear();
                    wordToBecheckedOnRows.Clear();

                }

                wordToBecheckedOnCols.Clear();
                wordToBecheckedOnRows.Clear();
            }
            
            return this.validWordsHolder.Distinct().ToList();
        }

    }
}


