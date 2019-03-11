using App1.Models;
using App1.Services;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchesPage : ContentPage
	{
        HttpService httpService = new HttpService();

        List<Team> teams = new List<Team>();

        ObservableCollection<Team> obsTeams;

        private Team oldTeam = null;
        private int CurrentPage = 1;

        public MatchesPage ()
		{
			InitializeComponent ();

            obsTeams = new ObservableCollection<Team>((Task.Run(() => httpService.GetTeams(1)).Result));
            TeamList.ItemsSource = obsTeams;
        }

        private void ListViewItem_Tabbed(object sender, ItemTappedEventArgs e)
        {
            var team = e.Item as Team;

            if(team != oldTeam)
            {
                if(oldTeam != null)
                {
                    oldTeam.IsVisible = false;
                    team.IsVisible = true;                 
                    UpdateTeams(oldTeam);
                    oldTeam = team;
                }
                else
                {
                    team.IsVisible = true;
                    oldTeam = team;
                }
                
            }else if (team == oldTeam)
            {
                oldTeam = null; 
                team.IsVisible = false;
            }

            UpdateTeams(team);
        }

        private void UpdateTeams(Team team)
        {
            var Index = obsTeams.IndexOf(team);
            obsTeams.Remove(team);
            obsTeams.Insert(Index, team);
        }


        async void OnButtonClicked(object sender, EventArgs args)
        {            
            CurrentPage++;
            teams = ((Task.Run(() => httpService.GetTeams(CurrentPage)).Result));

            foreach (var item in teams)
            {
                obsTeams.Add(item);
            }
        }
    }
}