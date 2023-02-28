/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/20/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp ()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureEssentials()
            .ConfigureServices()
            .ConfigureViewModels()
            .ConfigurePages()
            .ConfigureFonts(fonts => {
                fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
                fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                fonts.AddFont("Nunito-SemiBold.ttf", "NunitoSemiBold");
                fonts.AddFont("NunitoSans-Bold.ttf", "NunitoSansBold");
                fonts.AddFont("NunitoSans-Regular.ttf", "NunitoSansRegular");
                fonts.AddFont("NunitoSans-SemiBold.ttf", "NunitoSansSemiBold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
