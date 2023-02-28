/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/20/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.ViewModels.Base;

public abstract partial class BaseViewModel : ObservableObject, IBaseViewModel, IDisposable
{
    private bool disposedValue;
    private readonly SemaphoreSlim _isBusyLock = new(1, 1);

    public BaseViewModel (
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
    {
        DialogService = dialogService;
        NavigationService = navigationService;
        SettingsService = settingsService;
        GlobalSettings.Instance.BaseIdentityEndpoint = SettingsService.IdentityEndpointBase;
        GlobalSettings.Instance.BaseGatewayShoppingEndpoint = SettingsService.GatewayShoppingEndpointBase;
        GlobalSettings.Instance.BaseGatewayMarketingEndpoint = SettingsService.GatewayMarketingEndpointBase;
    }


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty]
    string _title;

    [ObservableProperty]
    bool _isInitialized;

    public IDialogService DialogService { get; private set; }
    public INavigationService NavigationService { get; private set; }
    public ISettingsService SettingsService { get; private set; }

    public virtual void ApplyQueryAttributes (IDictionary<string, object> query)
    {
    }

    public virtual Task InitializeAsync ()
    {
        return Task.CompletedTask;
    }

    public async Task IsBusyFor (
        Func<Task> unitOfWork)
    {
        await _isBusyLock.WaitAsync();
        try
        {
            IsBusy = true;
            await unitOfWork();
        }
        finally
        {
            IsBusy = false;
            _isBusyLock.Release();
        }
    }

    protected virtual void Dispose (bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~BaseViewModel()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose ()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}


