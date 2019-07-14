using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Data
{
    public class ScoreKeeper
    {
        public void RegisterAccount(string name, int score)
        {
            string account = name + " - " + score.ToString();
            string accounts = string.Empty;

            using (WebClient client = new WebClient())
            {
                accounts = client.UploadString("https://raw.githubusercontent.com/DKatsarski/SoftServe/master/Crossword/Crossword/words/score.txt", account);
            }
        }

        public void GetTopFiveScores()
        {
            string scores = string.Empty;
            var bestScores = new List<string>();
            using (WebClient client = new WebClient())
            {
                scores = client.DownloadString("https://raw.githubusercontent.com/DKatsarski/SoftServe/master/Crossword/Crossword/words/score.txt");
            }


        }

      
    }
}
