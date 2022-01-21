using System;
using Pokedex.App.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pokedex.App.DataAccess
{
    public class PokemonDataAccess
    {
        public async Task<List<Pokemon>> ObterTodos()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.canalti.com.br/api/pokemons.json");
                var response = client.GetAsync("");

                string data = await response.Result.Content.ReadAsStringAsync();

                var root = JsonConvert.DeserializeObject<Root>(data);

                if (root == null) return null;
                    
                return root.Pokemon;
            }
        }

        
    }
}
