/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/27/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.Services.Navigation;

public interface INavigationService
{
    Task InitializeAsync ();
    Task PopAsync ();
    Task NavigateToAsync (string route, IDictionary<string, object> parameters = null);
}
