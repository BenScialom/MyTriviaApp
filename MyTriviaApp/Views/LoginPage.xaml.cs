using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginPageViewModel();
	}
}