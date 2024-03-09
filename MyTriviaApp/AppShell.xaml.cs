using MyTriviaApp.ViewModels;

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
            Routing.RegisterRoute("ApproveQuestions", typeof(ApproveQuestionsPageViewModel));
            Routing.RegisterRoute("BestScores", typeof(BestScoresPageViewModel));
            Routing.RegisterRoute("LoginPage", typeof(LoginPageViewModel));
            Routing.RegisterRoute("UserAdmin", typeof(UserAdminPageViewModel));
            Routing.RegisterRoute("UserQuestions", typeof(UserQuestionsPageViewModel));
           
        }
    }
}