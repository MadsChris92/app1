using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace App1.Models
{
    class Team
    {
        public string slug { get; set; }

        public string name { get; set; }

        public int id { get; set; }

        public List<Player> players { get; set; }

        public string image_url { get; set; }

        public bool IsVisible { get; set; }

        public Team()
        {
            IsVisible = false;
        }
    }
}
