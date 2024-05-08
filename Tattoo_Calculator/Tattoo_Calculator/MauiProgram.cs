using Microsoft.Extensions.Logging;
using Tattoo_Calculator.Controls;

namespace Tattoo_Calculator {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("Windsong.ttf", "Windsong");
                    fonts.AddFont("PlayfairDisplaySC-Black.otf", "PlayfairDisplaySC");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<TattooPage>();

            return builder.Build();
        }
    }
}
