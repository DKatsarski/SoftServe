using System.Collections.Generic;

namespace Crossword.Operators.Contracts
{
    public interface IWordsOperator
    {
        List<string> ListOfAllWords { get; }

        IList<string> GetListOfAllWordsFromASpecifiedBeginning(string specificBeginningOfAWord);
    }
}