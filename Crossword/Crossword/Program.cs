using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    class Program
    {
        static void Main()
        {
            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();
            NetSpell.SpellChecker.Dictionary.Word word = new NetSpell.SpellChecker.Dictionary.Word();

            

            foreach (var item in oDict.BaseWords)
            {
                Console.WriteLine(item);
            }

            oDict.DictionaryFile = "en-US.dic";

            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine(oDict.Contains("door"));
            }
            //oDict.Initialize();
            //string wordToCheck = "door";
            //NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();

            //oSpell.Dictionary = oDict;
            //if (!oSpell.TestWord(wordToCheck))
            //{
            //}
        }
    }
}
