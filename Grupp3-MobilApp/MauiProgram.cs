using Grupp3_MobilApp.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace Grupp3_MobilApp
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
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Services.AddSingleton<IElevatorService, ElevatorService>();
        builder.Services.AddSingleton<IErrandService, ErrandService>();
        builder.Services.AddSingleton<ITechnicianService, TechnicianService>();
        builder.Services.AddSingleton<ICommentService, CommentService>();
#endif


            return builder.Build();
        }
    }
}