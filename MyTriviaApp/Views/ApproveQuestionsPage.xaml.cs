using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;

public partial class ApproveQuestionsPage : ContentPage
{
	public ApproveQuestionsPage(ApproveQuestionsPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}