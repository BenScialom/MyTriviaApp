using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class PlayerDetailsPage : ContentPage
{
    public PlayerDetailsPage(PlayerDetailsPageViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}