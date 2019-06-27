using System.Collections.Generic;

namespace Crossword.Contracts
{
    public interface IWordsOperator
    {
        List<string> ListOfAllWords { get; }

        List<string> GetListOfAllWordsFromASpecifiedBeginning(string specificBeginningOfAWord);
    }
}