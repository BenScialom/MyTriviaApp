namespace MyTriviaApp.Views;
using MyTriviaApp.ViewModels;

public partial class UserAdminPage : ContentPage
{
	public UserAdminPage(UserAdminPageViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}