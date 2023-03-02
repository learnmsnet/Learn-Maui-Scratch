/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/21/2023
 * Modified: 3/1/2023
 */

namespace Microsoft.Maui.Hosting;

public static class BuilderExtensions
{
    public static MauiAppBuilder ConfigureServices (
        this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IRequestService, RequestService>();
        builder.Services.AddSingleton<ILocationService, LocationService>();
        builder.Services.AddSingleton<IOpenUrlService, OpenUrlService>();
        builder.Services.AddSingleton<IThemeService, ThemeService>();
        builder.Services.AddSingleton<IIdentityService, IdentityService>();

        builder.Services.AddSingleton<IAppEnvironmentService, AppEnvironmentService>(
            serviceProvider => {
                var settingsService = serviceProvider.GetService<ISettingsService>();

                var aes = new AppEnvironmentService();
                aes.UpdateDependencies(settingsService.UseMocks);
                return aes;
            });

        return builder;
    }

    public static MauiAppBuilder ConfigureViewModels (
        this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<OnBoardingViewModel>();
        return builder;
    }

    public static MauiAppBuilder ConfigurePages (
        this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<OnBoardingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<HomePage>();

        return builder;
    }
}
