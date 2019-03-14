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
        private ObservableCollection<Match> obsMatches;
        private HttpService httpService = new HttpService();
        private Team team;
        private int currentUpcommingPage = 1;

        public TeamDetailPage (Team team)
		{
            this.team = team;
			InitializeComponent ();
            obsMatches = new ObservableCollection<Match>((Task.Run(() =>
                httpService.GetMatches(currentUpcommingPage, team)).Result));

            BindingContext = new TeamDetailViewModel(team, obsMatches);



            Console.Write(obsMatches);
        }
    }
}