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

            if (listOfWords.Exists(x => Regex.Match(x, pattern).Success))
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
