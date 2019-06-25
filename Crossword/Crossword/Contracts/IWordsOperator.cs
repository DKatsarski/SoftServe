using System.Collections.Generic;

namespace Crossword.Generators.Contracts
{
    public interface IWordsOperator
    {
        IList<string> ListOfAllWords { get; }

        IList<string> GetListOfAllWordsFromASpecifiedBeginning(string specificBeginningOfAWord);
    }
}