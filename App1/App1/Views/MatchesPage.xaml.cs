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

        TeamsViewmodel viewModel;

        int CurrentPage = 1;

        public MatchesPage ()
		{
			InitializeComponent ();

            obsTeams = new ObservableCollection<Team>((Task.Run(() => httpService.GetTeams(1)).Result));

            TeamList.ItemsSource = obsTeams;

            BindingContext = new TeamsViewmodel(teams);
        }


        async void OnButtonClicked(object sender, EventArgs args)
        {            
            CurrentPage++;
            teams = ((Task.Run(() => httpService.GetTeams(CurrentPage)).Result));

            foreach (var item in teams)
            {
                obsTeams.Add(item);
            }
            //myList.ItemsSource = obsTeams;
        }
    }
}