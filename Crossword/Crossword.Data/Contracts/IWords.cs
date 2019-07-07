using System.Collections.Generic;

namespace Crossword.Data
{
    public interface IWords
    {
        string[] GetAplphabet { get; }
        List<string> GetWords { get; }
    }
}