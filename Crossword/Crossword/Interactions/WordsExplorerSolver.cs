using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Interactions
{
    public class WordsExplorerSolver
    {
        private Painter painter;
        private List<string> guessedWords;

        public WordsExplorerSolver()
        {
            this.painter = new Painter();
            this.guessedWords = new List<string>();
        }

        public void GuessAWord(string[,] fieldOfCodedWords, List<string> listOfDecodedWords, string guessedWord)
        {
            while (true)
            {
                if (guessedWord.ToLower() == "exit")
                {
                    painter.ExitScreen();
                    break;
                }

                if (listOfDecodedWords.Contains(guessedWord))
                {
                    guessedWords.Add(guessedWord);
                    this.painter.RevealWord(fieldOfCodedWords, guessedWords);
                }
                else
                {
                    Counter.CounterOfWrongAnswers();
                }

                this.painter.RevealWord(fieldOfCodedWords, guessedWords);
                painter.GuessingAWordVisualizer(listOfDecodedWords);

                guessedWord = Console.ReadLine();
            }

        }
    }
}
