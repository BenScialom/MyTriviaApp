namespace MyTriviaApp.Views;
using MyTriviaApp.ViewModels;
public partial class BestScoresPage : ContentPage
{
	public BestScoresPage(BestScoresPageViewModel vm)
	{
		
		InitializeComponent();
		this.BindingContext = vm;
	}
}