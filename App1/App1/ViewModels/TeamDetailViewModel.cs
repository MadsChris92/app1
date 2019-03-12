using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class TeamDetailViewModel : BaseViewModel
    {
        Team team { get; set; }

        public TeamDetailViewModel(Team team)
        {
            this.team = team;
        }
    }
}
