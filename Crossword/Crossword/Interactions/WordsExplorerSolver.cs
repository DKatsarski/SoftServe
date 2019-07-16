using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Interactions
{
    public class WordsExplorerSolver
    {
        public void GuessAWord(string[] listOfDecodedWords, string guessedWord)
        {
            if (listOfDecodedWords.Contains(guessedWord))
            {

            }
            else
            {
                Counter.CounterOfWrongAnswers();
            }
        }
    }
}
