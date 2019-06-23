using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class RandomGenerator
    {
        private const int MinIndexOfList = 0;
        private Random randomGenerator;


        public RandomGenerator()
        {
            this.randomGenerator = new Random();
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
    }
}
