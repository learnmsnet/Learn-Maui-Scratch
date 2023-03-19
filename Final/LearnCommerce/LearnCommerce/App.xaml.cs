/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/20/2023
 * Modified: 3/11/2023
 */

#pragma warning disable GlobalUsingsAnalyzer // Using should be in global file
using Microsoft.Maui.Platform;
#pragma warning restore GlobalUsingsAnalyzer // Using should be in global file

namespace LearnCommerce;

public partial class App : Application
{
    private readonly ISettingsService _settingsService;
    private readonly INavigationService _navigationService;
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ILocationService _locationService;
    private readonly IThemeService _themeService;

    public App(
        ISettingsService settingsService,
        INavigationService navigationService,
        IAppEnvironmentService appEnvironmentService,
        ILocationService locationService,
        IThemeService themeService)
    {
        _settingsService = settingsService;
        _navigationService = navigationService;
        _appEnvironmentService = appEnvironmentService;
        _locationService = locationService;
        _themeService = themeService;

        InitializeComponent();
        InitApp();
        MainPage = new AppShell(_navigationService);
    }

    private void InitApp()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) => {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        if (VersionTracking.IsFirstLaunchEver)
        {
#if DEBUG
            _settingsService.UseMocks = true;
#endif
        }

        if (!_settingsService.UseMocks)
        {
            _appEnvironmentService.UpdateDependencies(_settingsService.UseMocks);
        }
    }
}
