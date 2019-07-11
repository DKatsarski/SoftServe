using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Crossword.Data
{
    public class EnglishWordsDictionary : IWords
    {
        private List<string> englishWords;
        private string[] englishAlphabet;
        

        public EnglishWordsDictionary()
        {
            this.englishWords = new List<string>();
            this.englishAlphabet = new string[] { "a", "b", "c", "d", "e",
                "f", "g", "h", "i", "j", "k", "l", "m", "n", "o",
                "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        }

        public string[] GetAplphabet => this.englishAlphabet;

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
