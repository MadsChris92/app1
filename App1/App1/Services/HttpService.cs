using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class HttpService
    {
        HttpClient Client { get; set; }
        string Key = "PUbBYoQNl8UBcjZ0nvOHSPbJEGMEHtV75-437VksZ2bsKdNOb34";
        string url = "https://api.pandascore.co/csgo/teams";
        public HttpService()
        {
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<List<Team>> GetTeams(int num)
        {
            var teams = new List<Team>();

            var uri = $"{url}?page={num}&sort=name&token={Key}";
               
            var response = await Client.GetAsync(uri);
          
            var content = await response.Content.ReadAsStringAsync();
            teams = JsonConvert.DeserializeObject<List<Team>>(content);
            return teams;    
        }

        public async Task<List<Match>> GetMatches(int num, Team team)
        {
            
            var matches = new List<Match>();
            var uri = $"https://api.pandascore.co/csgo/matches/upcoming?page={num}&token={Key}";

            var response = await Client.GetAsync(uri);

            var content = await response.Content.ReadAsStringAsync();
            matches = JsonConvert.DeserializeObject<List<Match>>(content);
            

            return matches.FindAll(x => x.opponents.Exists(t => t.id == team.id) == true);
        }
    }
}
