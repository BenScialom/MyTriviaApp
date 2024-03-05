using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}