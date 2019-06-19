using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Data
{
    public class EnglishWordsDictionary : IWords
    {
        private List<string> englishWords;

        public EnglishWordsDictionary()
        {
            this.englishWords = new List<string>();
        }

        public List<string> GetWords
        {
            get
            {
                this.englishWords = System.IO.File.ReadAllLines(@"C:\Users\dkats\Desktop\Programming\SoftServe\Crossword\Crossword\words\words.txt").ToList();
                return this.englishWords;
            }
        }
    }
}
