using System.Collections.Generic;

namespace Crossword.Contracts
{
    public interface IRandomGenerator
    {
        string GenerateRandomLetter(string[] alphabet);
        int GenerateRandomNumberFromListOfStrings(List<string> listOfWords);
        string GenerateRandomWord(List<string> wordsToExtractFrom);
    }
}