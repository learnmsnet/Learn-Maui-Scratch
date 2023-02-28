/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/20/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.ViewModels.Base;

public interface IBaseViewModel : IQueryAttributable
{
    public IDialogService DialogService { get; }
    public INavigationService NavigationService { get; }
    public ISettingsService SettingsService { get; }
    public bool IsBusy { get; }
    public bool IsInitialized { get; set; }
    Task InitializeAsync ();
}
