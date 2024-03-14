using MyTriviaApp.Models;
using MyTriviaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTriviaApp.ViewModels
{
    public class UserAdminPageViewModel : ViewModel
    {
        //רן
        private Service service;
        private List<Player> fullList;
        private Rank selectedRank;
        private Rank filteredRank;
        private string playerName;
        private string playerPassword;
        private string playerMail;
        private bool isRefreshing;
        private bool filtered;
        private bool isAddedMessageError;
        private bool isAddedMessageSuccess;
        public ObservableCollection<Player> Players { get; set; }
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        public Rank SelectedRank { get => selectedRank; set { selectedRank = value; OnPropertyChanged(); } }
        public List<Rank> Ranks { get; private set; }
        public string PlayerName { get => playerName; set { playerName = value; OnPropertyChanged(); } }
        public string PlayerPassword { get => playerPassword; set { playerPassword = value; OnPropertyChanged(); } }
        public string PlayerMail { get => playerMail; set { playerMail = value; OnPropertyChanged(); } }
        public bool IsAddedMessageError { get => isAddedMessageError; set { isAddedMessageError = value; OnPropertyChanged(); } }
        public bool IsAddedMessageSuccess { get => isAddedMessageSuccess; set { isAddedMessageSuccess = value; OnPropertyChanged(); } }


        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand LoadPlayersCommand { get; private set; }
        public ICommand AddPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand ResetPointsCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public UserAdminPageViewModel(Service service)
        {
            this.service = service;
            fullList = new List<Player>();
            SelectedRank = null;
            Ranks = service.GetRanks();
            IsRefreshing = false;
            PlayerName = "";
            PlayerMail = "";
            PlayerPassword = "";
            Players = new ObservableCollection<Player>();
            filtered = false;
            IsAddedMessageSuccess = false;
            IsAddedMessageError = false;
            filteredRank = null;


            ClearPlayersCommand = new Command(ClearPlayers);
            RemovePlayerCommand = new Command(async (object obj) => await RemovePlayer((Player)obj));//מחיקת התלמיד מהרשימה
            ResetPointsCommand = new Command(async (object obj) => await ResetPlayerPoints((Player)obj));
            LoadPlayersCommand = new Command(async () => await LoadPlayers());
            AddPlayerCommand = new Command(async () => { bool isAdded = AddPlayer(); await DisplayAddedPlayerMessage(isAdded); });
            FilterCommand = new Command(() => FilterPlayers(false)); ;
            ClearFilterCommand = new Command(() => ClearFilter());
            RefreshCommand = new Command(async () => await Refresh());

            this.LoadPlayersCommand.Execute(null);
        }
        private void ClearPlayers()
        {
            Players.Clear();
            ((Command)ClearPlayersCommand).ChangeCanExecute();

        }
        private async Task LoadPlayers()
        {
            IsRefreshing = true;
            fullList = await service.GetPlayers();
            Players.Clear();
            foreach (var player in fullList)
            {
                Players.Add(player);
            }
            ((Command)ClearPlayersCommand).ChangeCanExecute();
            IsRefreshing = false;

        }
        private void FilterPlayers(bool isRefresh)
        {
            Rank filterRank = selectedRank;
            if (isRefresh)
                filterRank = filteredRank;

            if (filterRank != null && fullList != null && fullList.Count > 0)
            {
                try
                {
                    var FilterByRanks = fullList.Where(x => x.Rank == filterRank).ToList();

                    Players.Clear();

                    foreach (var player in FilterByRanks)
                        Players.Add(player);
                    filtered = true;
                    filteredRank = SelectedRank;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        private void ClearFilter()
        {
            IsRefreshing = true;
            Players.Clear();
            foreach (var player in fullList)
            {
                Players.Add(player);
            }
            SelectedRank = null;
            filteredRank = null;
            ((Command)ClearPlayersCommand).ChangeCanExecute();
            IsRefreshing = false;
            filtered = false;
        }
        private async Task Refresh()
        {
            await LoadPlayers();
            FilterPlayers(true);
        }
        private bool AddPlayer()
        {
            if (!fullList.Any(x => x.Mail == playerMail))
            {
                Rank rookieRank = service.GetRanks()[2];
                Player newPlayer = new Player() { Mail = playerMail, Password = playerPassword, Points = 0, RankId = rookieRank.GetRankId(2), Rank = rookieRank, Name = playerName };
                fullList.Add(newPlayer);
                if (!filtered || (filteredRank == rookieRank && filtered))
                    Players.Add(newPlayer);
                service.AddPlayer(newPlayer);
                PlayerMail = null;
                PlayerName = null;
                PlayerPassword = null;
                return true;

            }
            return false;
        }
        private async Task RemovePlayer(Player p)
        {
            IsRefreshing = true;
            Players.Remove(p);
            fullList.Remove(p);
            await service.RemovePlayer(p);
            IsRefreshing = true;
        }
        private async Task ResetPlayerPoints(Player p)
        {
            p.Points = 0;
            service.UpdatePlayer(p);
            int pos = fullList.IndexOf(p);
            fullList.RemoveAt(pos);
            fullList.Insert(pos, p);
            await Refresh();
        }
        private async Task DisplayAddedPlayerMessage(bool isAdded)
        {
            if (isAdded)
            {
                IsAddedMessageSuccess = true;
                await Task.Delay(3000);
                IsAddedMessageSuccess = false;
            }
            else
            {
                IsAddedMessageError = true;
                await Task.Delay(3000);
                IsAddedMessageError = false;

            }

        }






    }
}