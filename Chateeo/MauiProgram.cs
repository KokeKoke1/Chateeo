using Chateeo.Services;
using Chateeo.Services.Authentication;
using Chateeo.Views;
using Microsoft.Extensions.Logging;

namespace Chateeo
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

            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<FetchService>();
            builder.Services.AddSingleton<ChatsService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
