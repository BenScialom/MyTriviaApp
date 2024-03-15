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
            Routing.RegisterRoute("ApproveQuestions", typeof(ApproveQuestionsPage));//Ben
            Routing.RegisterRoute("BestScores", typeof(BestScoresPage));//Itamar
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("UserAdmin", typeof(UserAdminPage));
           
            Routing.RegisterRoute("PlayerDetails", typeof(PlayerDetailsPage));//Ran
            Routing.RegisterRoute("Menu", typeof(MenuPage));

        }
    }
}