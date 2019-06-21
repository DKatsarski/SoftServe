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

        public WordsOperator(IWords words)
        {
            this.words = words;
            this.randomGenerator = new Random();
            //important to be declared just once to optimize resources
            this.listOfWords = this.words.GetWords;
        }

        public IList<string> ListOfAllWords
        {
            get
            {
                return this.listOfWords;
            }
        }

        public string GenerateRandomWord()
        {
            int maxIndexOfWordsList = listOfWords.Count;
            int randomIndexNumber = randomGenerator.Next(MinIndexOfList, maxIndexOfWordsList);
            var randomWord = listOfWords[randomIndexNumber];
            return randomWord;
        }

        public string GenerateRandomLetter(string[] alphabet)
        {
            int maxcIndexOfAlphabetList = alphabet.Length;
            int randomIndexNuber = randomGenerator.Next(MinIndexOfList, maxcIndexOfAlphabetList);
            var randomLetter = alphabet[randomIndexNuber];
            return randomLetter;
        }
    }
}
