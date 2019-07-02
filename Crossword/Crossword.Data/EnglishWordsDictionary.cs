using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public string[] EnglishAplphabet => new string[] { "a", "b", "c", "d", "e",
                "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public List<string> GetWords
        {
            get
            {
                string words = string.Empty;
                using (WebClient client = new WebClient())
                {
                    words = client.DownloadString("https://raw.githubusercontent.com/DKatsarski/SoftServe/master/Crossword/Crossword/words/wordList.txt");
                }
                this.englishWords = words.Split().ToList();
                return this.englishWords;
            }
        }
    }
}
