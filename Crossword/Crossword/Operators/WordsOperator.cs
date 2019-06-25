using Crossword.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossword.Operators.Contracts;


namespace Crossword.Operators
{
    public class WordsOperator : IWordsOperator
    {
        private IWords words;
        private IList<string> listOfWords;
        private IList<string> listOfWordsFromASpecificBeggining;

        public WordsOperator(IWords words)
        {
            this.words = words;
            this.listOfWordsFromASpecificBeggining = new List<string>();
        }

        public IList<string> ListOfAllWords
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
    }
}
