using Crossword.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Operators.Contracts;
using Crossword.Constants;

namespace Crossword.Operators
{
    public class WordsOperator : IWordsOperator
    {
        private IWords words;
        private List<string> listOfWords;
        private IList<string> listOfWordsFromASpecificBeggining;

        public WordsOperator(IWords words)
        {
            this.words = words;
            this.listOfWordsFromASpecificBeggining = new List<string>();
        }

        public List<string> ListOfAllWords
        {
            get
            {
                //important to be declared just once to optimize resources
                this.listOfWords = this.words.GetWords;
                return this.listOfWords;
            }
        }

        public IList<string> GetListOfAllWordsFromASpecifiedBeginning(string specificBeginningOfAWord)
        {
            this.listOfWordsFromASpecificBeggining =
                this.listOfWords
                .Where(x => x.StartsWith(specificBeginningOfAWord))
                .ToList();
            return this.listOfWordsFromASpecificBeggining;
        }

        public string ExtractFrameOfAPotentialWord(string potentialWord)
        {
            int lastOccuranceOfALetter = 0;
            string frameOfAPotentialWord = string.Empty;
            for (int i = potentialWord.Length - 1; i >= 0 ; i--)
            {
                if (potentialWord[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    lastOccuranceOfALetter = i;
                    frameOfAPotentialWord = potentialWord.Substring(0, lastOccuranceOfALetter + 1);
                    break;
                }
            }

            return frameOfAPotentialWord;
        }
    }
}
