using MyTriviaApp.Services;
using MyTriviaApp.ViewModels;
using MyTriviaApp.Views;

namespace MyTriviaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        private void RoutingPages()
        {
            Routing.RegisterRoute("ApproveQuestions", typeof(ApproveQuestionsPage));
            Routing.RegisterRoute("BestScores", typeof(BestScoresPage));
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("UserAdmin", typeof(UserAdminPage));
            Routing.RegisterRoute("UserQuestions", typeof(UserQuestionsPage));
          

        }
    }
}