using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Questao02
{
    class Program
    {
        public class Match
        {
            public string? competition { get; set; }
            public int year { get; set; }
            public string? round { get; set; }
            public string? team1 { get; set; }
            public string? team2 { get; set; }
            public string? team1goals { get; set; }
            public string? team2goals { get; set; }
        }
        public class TeamMatches
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<Match>? data { get; set; }
        }

        public static int getTotalScoredGoals(string team, int year, int teamSide)
        {
            var totalScoredGoals = 0;
            using (var client = new HttpClient())
            {
                var endpointTeam1 = new Uri("https://jsonmock.hackerrank.com/api/football_matches?year=" + year + "&team" + teamSide + "=" + team);
                var response1 = client.GetAsync(endpointTeam1).Result;
                var json = response1.Content.ReadAsStringAsync().Result;
                var teamMatches = JsonConvert.DeserializeObject<TeamMatches>(json);
                var matchesData = teamMatches?.data;

                if (teamMatches.total_pages > 1)
                {
                    var page = 0;
                    for (page = 2; page <= teamMatches.total_pages; page++)
                    {
                        var endpointPerPage = new Uri("https://jsonmock.hackerrank.com/api/football_matches?year=" + year + "&team" + teamSide + "=" + team + "&page=" + page);
                        var responsePerPage = client.GetAsync(endpointPerPage).Result;
                        var jsonPerPage = responsePerPage.Content.ReadAsStringAsync().Result;
                        var teamMatchesPerPage = JsonConvert.DeserializeObject<TeamMatches>(jsonPerPage);
                        var matchesPerPage = teamMatchesPerPage?.data;
                        var x = 0;
                        for (x = 0; x < matchesPerPage?.Count; x++)
                        {
                            matchesData?.Add(matchesPerPage[x]);
                        }
                    }
                }
                var loop1 = teamMatches.total;
                var i = 0;
                for (i = 0; i < loop1; i++)
                {
                    if (teamSide == 1)
                    {
                        totalScoredGoals += int.Parse(matchesData[i].team1goals);
                    }
                    else
                    {
                        totalScoredGoals += int.Parse(matchesData[i].team2goals);
                    }
                }
            }

            return totalScoredGoals;
        }
        static void Main(string[] args)
        {
            string teamName = "Paris Saint-Germain";
            int year = 2013;
            int totalGoals = getTotalScoredGoals(teamName, year, 1) + getTotalScoredGoals(teamName, year, 2);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

            teamName = "Chelsea";
            year = 2014;
            totalGoals = getTotalScoredGoals(teamName, year, 1) + getTotalScoredGoals(teamName, year, 2);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);
        }
    }
}
