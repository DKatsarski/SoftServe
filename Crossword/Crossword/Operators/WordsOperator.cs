using Crossword.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Generators
{
    public class WordsOperator
    {
        private const int MinIndexOfList = 0;
        private IWords words;
        private Random randomGenerator;
        private IList<string> listOfWords;
        private IList<string> listOfWordsFromASpecificBeggining;

        public WordsOperator(IWords words)
        {
            this.words = words;
            this.randomGenerator = new Random();
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


        public string GenerateRandomWord(IList<string> wordsToExtractFrom)
        {
            int maxIndexOfWordsList = wordsToExtractFrom.Count - 1;
            int randomIndexNumber = randomGenerator.Next(MinIndexOfList, maxIndexOfWordsList);
            var randomWord = wordsToExtractFrom[randomIndexNumber];
            return randomWord;
        }

        public string GenerateRandomLetter(string[] alphabet)
        {
            int maxcIndexOfAlphabetList = alphabet.Length - 1;
            int randomIndexNuber = randomGenerator.Next(MinIndexOfList, maxcIndexOfAlphabetList);
            var randomLetter = alphabet[randomIndexNuber];
            return randomLetter;
        }

        public IList<string> GetListOfAllWordsFromASpecifiedBeggining(string specificBegginingOfAWord)
        {
            this.listOfWordsFromASpecificBeggining =
                this.listOfWords
                .Where(x => x.StartsWith(specificBegginingOfAWord))
                .ToList();
            return this.listOfWordsFromASpecificBeggining;
        }
    }
}
