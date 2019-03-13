using App1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    class TeamDetailViewModel : BaseViewModel
    {
        public Team team { get; set; }
        public ObservableCollection<Match> obsMatches { get; set; }

        public TeamDetailViewModel(Team team, ObservableCollection<Match> obsMatches)
        {
            this.obsMatches = obsMatches;
            this.team = team;
        }
    }
}
