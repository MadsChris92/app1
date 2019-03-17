using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Match
    {
        

        public string status { get; set; }

        public List<Opponent> opponents { get; set; }

        public int id { get; set; }

        public DateTime begin_at { get; set; }

        public int? number_of_games { get; set; }

        public string name { get; set; }

        public string match_type { get; set; }

    }
}
