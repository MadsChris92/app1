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

            var uri = $"{url}?page={num}&token={Key}";
                //https://api.pandascore.co/csgo/teams?token=PUbBYoQNl8UBcjZ0nvOHSPbJEGMEHtV75-437VksZ2bsKdNOb34";
              //new Uri(string.Format(Teams, Key));

            var response = await Client.GetAsync(uri);

            
            var content = await response.Content.ReadAsStringAsync();
            teams = JsonConvert.DeserializeObject<List<Team>>(content);
            return teams;    

        }
    }
}
