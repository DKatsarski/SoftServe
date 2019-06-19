using System.Collections.Generic;

namespace Crossword.Data
{
    public interface IWords
    {
         List<string> GetWords { get; }
    }
}