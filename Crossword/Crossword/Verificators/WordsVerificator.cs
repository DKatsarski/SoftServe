using Crossword.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crossword
{
    public class WordsVerificator
    {

        public bool ContainsWordWithSpecificBeginning(List<string> listOfWords, string beginningOfWord)
        {
            if (listOfWords.Exists(x => x.StartsWith(beginningOfWord)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsWordWithSpecificPositionOfCharacters(List<string> listOfWords, string pattern)
        {
            var lastIndexOfSpecifiedLetter = 0;
            var firstIndexOfSpecifiedLetter = 0;

            for (int i = pattern.Length - 1; i > 0; i--)
            {
                if (pattern[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    lastIndexOfSpecifiedLetter = i;
                    break;
                }
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != char.Parse(GlobalConstants.SpecificSymbolToReplaceNull))
                {
                    firstIndexOfSpecifiedLetter = i;
                    break;
                }
            }

            if (listOfWords.Exists(x => Regex.Match(x, pattern).Success &&
                x[lastIndexOfSpecifiedLetter] == pattern[lastIndexOfSpecifiedLetter] &&
                x[firstIndexOfSpecifiedLetter] == pattern[firstIndexOfSpecifiedLetter]))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool IsWordInList(List<string> listOfWords, string word)
        {
            if (listOfWords.Exists(x => x.Equals(word)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
