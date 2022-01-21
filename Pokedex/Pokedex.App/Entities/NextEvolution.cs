using Newtonsoft.Json;

namespace Pokedex.App.Entities
{
    public class NextEvolution
    {
        [JsonProperty("num")]
        public string Num { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
