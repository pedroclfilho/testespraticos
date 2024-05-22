using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class ModeloResultadoFootBall
    {
        [Required] [JsonProperty("page")] public int Page { get; set; }
        [Required] [JsonProperty("per_page")] public int PerPage { get; set; }
        [Required] [JsonProperty("total")] public int Total { get; set; }
        [Required] [JsonProperty("total_pages")] public int TotalPages { get; set; }
        [Required] [JsonProperty("data")] public List<DataModeloResultadoFootBall> Data  { get; set; }


    }
    /*
{"page":1,"per_page":10,"total":3,"total_pages":1,"data":[{"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"Atletico Madrid","team1goals":"0","team2goals":"2"},{"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"SL Benfica","team1goals":"2","team2goals":"1"},{"competition":"UEFA Champions League","year":2015,"round":"GroupC","team1":"Galatasaray","team2":"Astana","team1goals":"1","team2goals":"1"}]}     
     */
}
