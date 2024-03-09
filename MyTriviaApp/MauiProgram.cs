
using Microsoft.Extensions.Logging;
using MyTriviaApp.ViewModels;
using MyTriviaApp.Views;
using MyTriviaApp.Services;

namespace MyTriviaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<Service>();

      
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<BestScoresPageViewModel>();
            builder.Services.AddTransient<UserAdminPageViewModel>();
            builder.Services.AddTransient<UserQuestionsPageViewModel>();
            builder.Services.AddTransient<ApproveQuestionsPageViewModel>();
            builder.Services.AddTransient<PlayerDetailsPageViewModel>();
            builder.Services.AddTransient<MenuPageViewModel>();



            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<BestScoresPage>();
            builder.Services.AddTransient<ApproveQuestionsPage>();
            builder.Services.AddTransient<UserQuestionsPage>();
            builder.Services.AddTransient<UserAdminPage>();
            builder.Services.AddTransient<PlayerDetailsPage>();
            builder.Services.AddTransient<MenuPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}