using MyTriviaApp.ViewModels;

namespace MyTriviaApp.Views;
using MyTriviaApp.ViewModels;
public partial class ApproveQuestionsPage : ContentPage
{
	public ApproveQuestionsPage(ApproveQuestionsPageViewModel vm)
	{

		InitializeComponent();
		this.BindingContext = vm;
	}
}