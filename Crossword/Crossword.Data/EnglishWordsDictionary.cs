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

        public List<string> GetWords
        {
            get
            {

                WebClient client = new WebClient();
                var a = client.DownloadString("https://raw.githubusercontent.com/DKatsarski/SoftServe/master/Crossword/Crossword/words/wordList.txt").Split().ToList();
                this.englishWords = a.ToList();
                return this.englishWords;
            }
        }
    }
}
