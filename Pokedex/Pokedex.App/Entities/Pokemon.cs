using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pokedex.App.Entities
{
    public class Pokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("num")]
        public string Num { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("type")]
        public List<string> Type { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("candy")]
        public string Candy { get; set; }

        [JsonProperty("candy_count")]
        public string CandyCount { get; set; }

        [JsonProperty("egg")]
        public string Egg { get; set; }

        [JsonProperty("spawn_chance")]
        public string SpawnChance { get; set; }

        [JsonProperty("avg_spawns")]
        public string AvgSpawns { get; set; }

        [JsonProperty("spawn_time")]
        public string SpawnTime { get; set; }

        [JsonProperty("multipliers")]
        public List<string> Multipliers { get; set; }

        [JsonProperty("weaknesses")]
        public List<string> Weaknesses { get; set; }

        [JsonProperty("next_evolution")]
        public List<NextEvolution> NextEvolution { get; set; }

        [JsonProperty("prev_evolution")]
        public List<PrevEvolution> PrevEvolution { get; set; }
    }
}
