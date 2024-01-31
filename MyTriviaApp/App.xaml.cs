using MyTriviaApp.ViewModels;

namespace MyTriviaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginViewModel();
        }
    }
}