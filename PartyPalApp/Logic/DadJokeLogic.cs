using Newtonsoft.Json;
using PartyPalApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPalApp.Logic
{
    public class DadJokeLogic
    {
        public async static Task<List<Joke>> GetRandomJoke()
        {
            List<Joke> jokes = new List<Joke>();
            var url = DadJokeURL.GenerateURLRandom();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var joke = JsonConvert.DeserializeObject<Joke>(json);
                jokes.Add(joke);
            }

            return jokes;
        }
    }
}
