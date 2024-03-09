using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;


public partial class MenuPage : ContentPage
{
	public MenuPage(MenuPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}