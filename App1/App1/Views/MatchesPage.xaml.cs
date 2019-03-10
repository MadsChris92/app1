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

        TeamsViewmodel viewModel;



        public MatchesPage ()
		{
			InitializeComponent ();

            teams = (Task.Run(() => httpService.GetTeams(1)).Result);

            myList.ItemsSource = teams;

            BindingContext = new TeamsViewmodel(teams);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Team team = args.SelectedItem as Team;
            if (team == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            //// Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }


        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            teams = (Task.Run(() => httpService.GetTeams(2)).Result);
            myList.ItemsSource = teams;
        }
    }
}