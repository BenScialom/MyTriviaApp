using MyTriviaApp.ViewModels;
namespace MyTriviaApp.Views;


public partial class UserAdminPage : ContentPage
{
	public UserAdminPage(UserAdminPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}