using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class DataModeloResultadoFootBall
    {
        [Required] [JsonProperty("competition")] public string Competition { get; set; }
        [Required] [JsonProperty("year")] public int Year { get; set; }
        [Required] [JsonProperty("round")] public string Round { get; set; }
        [Required] [JsonProperty("team1")] public string Team1 { get; set; }
        [Required] [JsonProperty("team2")] public string Team2 { get; set; }
        [Required] [JsonProperty("team1goals")] public int Team1Goals { get; set; }
        [Required] [JsonProperty("team2goals")] public int Team2Goals { get; set; }
    }
    /*
{"page":1,"per_page":10,"total":3,"total_pages":1,"data":[
    {"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"Atletico Madrid","team1goals":"0","team2goals":"2"},
    {"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"SL Benfica","team1goals":"2","team2goals":"1"},
    {"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"Astana","team1goals":"1","team2goals":"1"}]}     
     */
}
