using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class UserQuestionsPage : ContentPage
{
	public UserQuestionsPage(UserQuestionsPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}