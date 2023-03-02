/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/20/2023
 * Modified: 3/1/2023
 */

using LearnCommerce.Pages;

namespace LearnCommerce;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigation;

    public AppShell (
        INavigationService navigation)
    {
        _navigation = navigation;
        InitializeRouting();
        InitializeComponent();
    }

    protected override async void OnHandlerChanged ()
    {
        base.OnHandlerChanged();
        if (Handler is not null)
        {
            await _navigation.InitializeAsync();
        }
    }

    private static void InitializeRouting ()
    {
        Routing.RegisterRoute("OnBoarding", typeof(OnBoardingPage));
        Routing.RegisterRoute(nameof(OnBoardingPage), typeof(OnBoardingPage));
        Routing.RegisterRoute("Login", typeof(LoginPage));
        Routing.RegisterRoute("Home", typeof(HomePage));
    }
}
