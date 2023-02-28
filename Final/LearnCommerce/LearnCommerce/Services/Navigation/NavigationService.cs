/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/27/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly ISettingsService _settings;

    public NavigationService (
        ISettingsService settings)
    {
        _settings = settings;
    }

    public Task InitializeAsync ()
    {
        if (!_settings.ContainsKey(LearnCommerceConstants.SHOWN_ONBOARDING))

        // if (VersionTracking.IsFirstLaunchEver)
        {
            // _settings.Set(NagranniConstants.SHOWN_ONBOARDING, true);
            return NavigateToAsync("//OnBoarding");

        }
        else
        {
            return NavigateToAsync(
                string.IsNullOrEmpty(_settings.AuthAccessToken)
                ? "//Login"
                : "//Home");
        }
    }


    public Task NavigateToAsync (string route, IDictionary<string, object> parameters = null)
    {
        var shellNav = new ShellNavigationState(route);
        return parameters != null
            ? Shell.Current.GoToAsync(shellNav, parameters)
            : Shell.Current.GoToAsync(shellNav);
    }

    public Task PopAsync () =>
        Shell.Current.GoToAsync("..");
}
