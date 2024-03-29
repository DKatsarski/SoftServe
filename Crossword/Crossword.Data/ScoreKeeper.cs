﻿using System.Collections.Generic;
using System.Net;

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
                accounts = client.UploadString("https://drive.google.com/file/d/1vioNVJWzUAoN2URDqmNO2E5CKasxJmFL/view?usp=sharing", account);
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
