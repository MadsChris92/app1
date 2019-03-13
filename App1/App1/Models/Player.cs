using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class Player
    {
        public string slug { get; set; }

        public string role { get; set; }

        public string name { get; set; }

        public string last_name { get; set; }

        public int id { get; set; }

        public string hometown { get; set; }

        public string first_name { get; set; }

        //public string image_url { get; set; }
        private string image_default { get; set; }

        public string image_url
        {
            get
            {
                return image_default;
            }
            set
            {
                if (value != null)
                {
                    image_default = value;
                }
                else
                {
                    image_default = @"..\Ressources\player.png";
                    //"Ressources/player.png";
                }
            }
        }
    }
}
