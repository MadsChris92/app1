using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1.ViewModels
{
	class TeamsViewmodel : INotifyPropertyChanged
	{
        public List<Team> Teams { get; set; }

        public string Title {
            get => "dasda";
        }
        public TeamsViewmodel (List<Team> teams)
		{
            Teams = teams;
		}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}