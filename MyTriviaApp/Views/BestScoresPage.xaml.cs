using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class BestScoresPage : ContentPage
{
	public BestScoresPage(BestScoresPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}