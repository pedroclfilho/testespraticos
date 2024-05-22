using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questao2 {
    public class Program
    {
        public static void Main()
        {
            string teamName = "Paris Saint-Germain";
            int year = 2013;
            int totalGoals = getTotalScoredGoals(teamName, year);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

            teamName = "Chelsea";
            year = 2014;
            totalGoals = getTotalScoredGoals(teamName, year);

            Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

            // Output expected:
            // Team Paris Saint - Germain scored 109 goals in 2013
            // Team Chelsea scored 92 goals in 2014
        }
        private static string ObterUrlFootBall(string team, int year, bool isTeam2 = false)
        {
            var teamNumber = isTeam2 ? "2" : "1";
            return $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team{teamNumber}={team}";
        }
        public static int getTotalScoredGoals(string team, int year)
        {
            var _task = getTotalScoredGoalsAsync(team, year);

            return _task.Result;
        }

        private static async Task<int> CalcTotalGoals(string url, bool isTeam2=false)
        {
            var page = 1;
            var totalPages = 1;
            var erro = 0;
            var httpClient = new HttpClient();
            int totalGoals = 0;
            do
            {
                try
                {
                    do
                    {

                        HttpResponseMessage response = await httpClient.GetAsync($"{url}&page={page}");
                        string responseData1 = await response.Content.ReadAsStringAsync();

                        var jObject = JObject.Parse(responseData1);
                        var responseString = jObject.ToString();
                        var result = JsonConvert.DeserializeObject<ModeloResultadoFootBall>(responseString);
                        totalPages = result?.TotalPages ?? totalPages;
                        totalGoals += (result?.Data.Sum(x => isTeam2 ? x.Team2Goals : x.Team1Goals)) ?? 0;
                        page++;
                    } while (page <= totalPages);
                    break;
                }
                catch (Exception ex)
                {
                    erro++;
                    if (erro > 5)
                    {
                        throw new Exception("Falha ao tentar obter resultado da Api de FootBall");
                    }
                }
            } while (1 == 1);

            return totalGoals;
        }
        public static async Task<int> getTotalScoredGoalsAsync(string team, int year)
        {
            var pageToGetTeam1 = ObterUrlFootBall(team, year);
            var pageToGetTeam2 = ObterUrlFootBall(team, year, true);
            var parcial1 = await CalcTotalGoals(pageToGetTeam1);
            var parcial2 = await CalcTotalGoals(pageToGetTeam2,true);
            return parcial1+parcial2;
        }
    }
}