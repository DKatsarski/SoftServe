using Crossword.Constants;
using Crossword.Contracts;
using System;
using System.Collections.Generic;

namespace Crossword.Generators
{
    public class RandomGenerator : IRandomGenerator
    {
        private Random randomGenerator;

        public RandomGenerator()
        {
            this.randomGenerator = new Random();
        }

        public string GenerateRandomWord(List<string> wordsToExtractFrom)
        {
            int maxIndexOfWordsList = wordsToExtractFrom.Count - 1;
            int randomIndexNumber = randomGenerator.Next(GlobalConstants.MinIndexOfList, maxIndexOfWordsList);
            var randomWord = wordsToExtractFrom[randomIndexNumber];
            return randomWord;
        }

        public string GenerateRandomLetter(string[] alphabet)
        {
            int maxcIndexOfAlphabetList = alphabet.Length - 1;
            int randomIndexNuber = randomGenerator.Next(GlobalConstants.MinIndexOfList, maxcIndexOfAlphabetList);
            var randomLetter = alphabet[randomIndexNuber];
            return randomLetter;
        }

        public int GenerateRandomNumberFromListOfStrings(List<string> listOfWords)
        {
            int randomNumber = randomGenerator.Next(GlobalConstants.MinIndexOfList, listOfWords.Count - 1);
            return randomNumber;
        }
    }
}
