using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class PlayerDetailViewModel
    {
        public Player player { get; set; }

        public PlayerDetailViewModel(Player player)
        {
            this.player = player;
        }
    }
}
