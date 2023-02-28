/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/21/2023
 * Modified: 2/27/2023
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

        return builder;
    }

    public static MauiAppBuilder ConfigureViewModels (
        this MauiAppBuilder builder)
    {

        return builder;
    }

    public static MauiAppBuilder ConfigurePages (
        this MauiAppBuilder builder)
    {

        return builder;
    }
}
