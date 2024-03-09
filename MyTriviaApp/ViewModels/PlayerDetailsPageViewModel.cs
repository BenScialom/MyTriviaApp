using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTriviaApp.Models;


namespace MyTriviaApp.ViewModels
{
    [QueryProperty(nameof(Player), "Player")]
    [QueryProperty(nameof(Title), "Title")]
    public class PlayerDetailsPageViewModel : ViewModel
    {
        private string title;
        private Player player;
        public Player Player { get => player; set { player = value; OnPropertyChanged(); } }


        public string Title { get => title; set { title = value; OnPropertyChanged(); } }

    }
}