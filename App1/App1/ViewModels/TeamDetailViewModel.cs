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
        public ObservableCollection<Match> upMatches { get; set; }
        public ObservableCollection<Match> results { get; set; }
        public ObservableCollection<Match> runMatches { get; set; }

        public bool teamNull { get; set; }

        public TeamDetailViewModel(Team team, 
            ObservableCollection<Match> upMatches, 
            ObservableCollection<Match> results,
            ObservableCollection<Match> runMatches)
        {
            this.upMatches = upMatches;
            this.results = results;
            this.runMatches = runMatches;

            this.team = team;

            if(team.players.Count > 0)
            {
                
            }else
            {
                teamNull = false;
            }
        }
    }
}
