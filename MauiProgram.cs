﻿using Microsoft.Extensions.Logging;

namespace PongFight
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
                })
                .UseMauiCommunityToolkitMarkup();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<GameViewModel>();
            builder.Services.AddTransient<GamePage>();

            return builder.Build();
        }
    }
}
