using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using App1.Services;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TeamDetailPage : ContentPage
	{
        private ObservableCollection<Match> upMatches;
        private ObservableCollection<Match> results;
        private ObservableCollection<Match> runMatches;
        private HttpService httpService = new HttpService();
        private Team team;
        private int currentUpcommingPage = 1;

        public TeamDetailPage (Team team)
		{
            this.team = team;
			InitializeComponent ();

            upMatches = new ObservableCollection<Match>((Task.Run(() =>
                httpService.GetTeamUpcommingMatches(currentUpcommingPage, team)).Result));

            results = new ObservableCollection<Match>((Task.Run(() =>
                httpService.GetTeamResults(currentUpcommingPage, team)).Result));

            runMatches = new ObservableCollection<Match>((Task.Run(() =>
                httpService.GetTeamRunningMatches(currentUpcommingPage, team)).Result));

            BindingContext = new TeamDetailViewModel(team, upMatches, results, runMatches);
        }
    }
}