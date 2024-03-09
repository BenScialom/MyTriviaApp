using MyTriviaApp.ViewModels;
using MyTriviaApp.Views;
namespace MyTriviaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RoutingPages();
        }

        private void RoutingPages()
        {
            Routing.RegisterRoute("ApproveQuestions", typeof(ApproveQuestionsPage));
            Routing.RegisterRoute("BestScores", typeof(BestScoresPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("UserAdmin", typeof(UserAdminPage));
            Routing.RegisterRoute("UserQuestions", typeof(UserQuestionsPage));
            Routing.RegisterRoute("PlayerDetails", typeof(PlayerDetailsPage));
            Routing.RegisterRoute("Menu", typeof(MenuPage));

        }
    }
}