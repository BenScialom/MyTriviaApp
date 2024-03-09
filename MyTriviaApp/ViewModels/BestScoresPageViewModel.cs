using MyTriviaApp.Services;
using MyTriviaApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace MyTriviaApp.ViewModels
{
    public class BestScoresPageViewModel : ViewModel
    {
        public ObservableCollection<Player> Players { get; set; }
        private List<Player> fullList;
        public ICommand LoadPlayersCommand { get; private set; }
        public ICommand ClearPlayersCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        private bool isOrdered;
        private Service service;
        private Player selectedPlayer;
        public Player SelectedPlayer { get => selectedPlayer; set { selectedPlayer = value; OnPropertyChanged(); ((Command)ShowPlayerCommand).ChangeCanExecute(); } }
        public ObservableCollection<string> RanksCollection { get; set; }
        public object SelectedRank { get; set; }
        private int selectedIndex;
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
        public ICommand FilterCommand { get; private set; }
        public ICommand ClearFilterCommand { get; private set; }
        public ICommand ShowPlayerCommand { get; private set; }
        public BestScoresPageViewModel(Service service)
        {
            this.service = service;
            fullList = new List<Player>();
            Players = new ObservableCollection<Player>();
            RanksCollection = new ObservableCollection<string>();

            LoadPlayersCommand = new Command(async () => await LoadPlayers());
            RefreshCommand = new Command(async () => await Refresh());
            ClearPlayersCommand = new Command(ClearPlayers, () => Players.Count > 0);
            FilterCommand = new Command(() =>
            {
                try
                {
                    var hasThisRank = fullList.Where(x => x.Rank.RankName == (string)SelectedRank).ToList();

                    Players.Clear();

                    foreach (var student in hasThisRank)
                        Players.Add(student);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }, () => fullList != null && fullList.Count > 0
            );
            ShowPlayerCommand = new Command(async () =>
            {
                bool result = await AppShell.Current.DisplayAlert("Player's Details Display", "Are you sure?", "Yes", "No");
                if (result)
                {
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("Player", selectedPlayer);
                    await AppShell.Current.GoToAsync($"PlayerDetailes?Title={selectedPlayer.Name}'s Details", data);
                    selectedPlayer = null;
                }
            }
            , () => selectedPlayer != null);
            ClearFilterCommand = new Command(async () => { await LoadPlayers(); }, () => fullList != null && fullList.Count > 0);
        }

        private async Task LoadPlayers()
        {
            IsRefreshing = false;
            fullList = await service.GetPlayersDeccending();
            Players.Clear();
            foreach (var player in fullList)
            {
                Players.Add(player);
            }
            isOrdered = true;
            UpdateRank();
            ((Command)ClearPlayersCommand).ChangeCanExecute();
            ((Command)FilterCommand).ChangeCanExecute();
            ((Command)ClearFilterCommand).ChangeCanExecute();
        }
        private async Task ChangeOrder()
        {
            IsRefreshing = true;
            var fullList = await service.GetPlayersAccending();
            Players.Clear();
            foreach (var player in fullList)
            {
                Players.Add(player);
            }
            isOrdered = false;
        }
        private async Task Refresh()
        {
            IsRefreshing = true;
            if (!isOrdered)
                await LoadPlayers();
            else
                await ChangeOrder();
            IsRefreshing = false;
        }
        private void ClearPlayers()
        {
            Players.Clear();
            RanksCollection.Clear();
            fullList.Clear();


            ((Command)ClearPlayersCommand).ChangeCanExecute();
            ((Command)FilterCommand).ChangeCanExecute();
            ((Command)ClearFilterCommand).ChangeCanExecute();

        }
        private void UpdateRank()
        {
            RanksCollection.Clear();
            var r = fullList.Select(x => x.Rank.RankName).Distinct().OrderBy(x => x);
            foreach (var x in r)
                RanksCollection.Add(x);
            SelectedIndex = -1;
        }
    }

}