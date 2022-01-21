using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pokedex.App.Entities
{
    public class Root
    {
        [JsonProperty("pokemon")]
        public List<Pokemon> Pokemon { get; set; }
    }
}
