/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/11/2023
 * Modified: 3/11/2023
 */

namespace LearnCommerce.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
    private readonly ILocationService _locationService;
    private readonly IAppEnvironmentService _appEnvironmentService;

    public SettingsViewModel(
        ILocationService locationService,
        IAppEnvironmentService appEnvironmentService,
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
        : base(dialogService, navigationService, settingsService)
    {
        _locationService = locationService;
        _appEnvironmentService = appEnvironmentService;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(UpdateCloudServicesCommand))]
    private bool _useCloudServices;

    [ObservableProperty]
    private bool _gatewayShoppingEndpoint;

    [ObservableProperty]
    private string _gpsWarningMessage;

    [RelayCommand]
    private void UpdateCloudServices()
    {
        SettingsService.UseMocks = !UseCloudServices;
    }
}
