using Crossword.Constants;
using Crossword.Contracts;
using Crossword.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Crossword.Operators
{
    public class WordsOperator : IWordsOperator
    {
        private IWords words;
        private List<string> listOfWords;
        private List<string> listOfWordsFromASpecificPattern;
        private List<string> collectedWordsFromCrossword;

        public WordsOperator(IWords words)
        {
            this.words = words;
            this.listOfWordsFromASpecificPattern = new List<string>();
            this.collectedWordsFromCrossword = new List<string>();
        }

        public List<string> CollectedWordsFromCrossword
        {
            get
            {
                return this.collectedWordsFromCrossword;
            }
            set
            {
                this.collectedWordsFromCrossword.Add(value.ToString());
            }
        }

        public List<string> ListOfAllWords
        {
            get
            {
                //important to be declared just once to optimize resources
                this.listOfWords = this.words.GetWords
                    .Where(x => Regex.Match(x, "^[A-Za-z]*$").Success)
                .ToList();
                return this.listOfWords;
            }
        }

        public List<string> GetListOfAllWordsFromASpecifiedBeginning(string specificBeginningOfAWord)
        {
            this.listOfWordsFromASpecificPattern =
                this.listOfWords
                .Where(x => x.StartsWith(specificBeginningOfAWord))
                .ToList();
            return this.listOfWordsFromASpecificPattern;
        }

        public List<string> GetListOfAllWordsFromASpecifiedPattern(string specificPatternOfAWord)
        {
            var lastIndexOfSpecifiedLetter = 0;
            var firstIndexOfSpecifiedLetter = 0;

            for (int i = specificPatternOfAWord.Length - 1; i > 0; i--)
            {
                if (specificPatternOfAWord[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    lastIndexOfSpecifiedLetter = i;
                    break;
                }
            }

            for (int i = 0; i < specificPatternOfAWord.Length; i++)
            {
                if (specificPatternOfAWord[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    firstIndexOfSpecifiedLetter = i;
                    break;
                }
            }

            this.listOfWordsFromASpecificPattern =
                this.listOfWords
                .Where(x => Regex.Match(x, specificPatternOfAWord).Success &&
                x[lastIndexOfSpecifiedLetter] == specificPatternOfAWord[lastIndexOfSpecifiedLetter] &&
                x[firstIndexOfSpecifiedLetter] == specificPatternOfAWord[firstIndexOfSpecifiedLetter])
                .ToList();

            return this.listOfWordsFromASpecificPattern;
        }

        public string ExtractFrameOfAPotentialWord(string potentialWord)
        {
            int lastOccuranceOfALetter = 0;
            string frameOfAPotentialWord = string.Empty;

            for (int i = potentialWord.Length - 1; i >= 0; i--)
            {
                if (potentialWord[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    lastOccuranceOfALetter = i;
                    frameOfAPotentialWord = potentialWord.Substring(0, lastOccuranceOfALetter + 1);
                    break;
                }
            }

            return frameOfAPotentialWord;
        }

        public string RevealGuessedLetters(List<string> listOfCharacters)
        {
            var revealedLetters = "[^";

            for (int i = 0; i < listOfCharacters.Count; i++)
            {
                revealedLetters += listOfCharacters[i];
            }

            revealedLetters += "]";
            return revealedLetters;
        }
    }
}
