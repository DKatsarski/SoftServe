﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp.Domain;
using WebApp.Services.ScoreService;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
    public class RankListController : Controller
    {
        private IScoreService scoreService;

        public RankListController(IScoreService _scoreService)
        {
            scoreService = _scoreService;
        }

        public IActionResult CurrentRankList()
        {
            Dictionary<string, int> ranklist = new Dictionary<string, int>();
            List<Rating> rating = scoreService.GetAllData();

            List<string> users = new List<string>();
            List<int> score = new List<int>();

            foreach (var item in rating)
            {
                users.Add(item.ReceiverId);
            }

            foreach (var item in rating)
            {
                int average = 0;
                int count = 0;

                foreach (var _score in item.Scores)
                {
                    average += _score.Points;
                    count++;
                }

                if (count != 0)
                {
                    average /= count;
                }
                else
                {
                    average /= 1;
                }
                score.Add(average);
            }

            for (int i = 0; i < users.Count; i++)
            {
                ranklist.Add(users[i], score[i]);
            }

            var sortedRankList = from entry in ranklist orderby entry.Value descending select entry;

            Dictionary<string, int> _sortedRankList = new Dictionary<string, int>();

            foreach (var item in sortedRankList)
            {
                _sortedRankList.Add(item.Key, item.Value);
            }

            return View(_sortedRankList);
        }
    }
}