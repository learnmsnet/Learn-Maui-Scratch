/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/10/2023
 * Modified: 3/11/2023
 */

namespace LearnCommerce.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly ISettingsService _settingsService;
    private readonly IOpenUrlService _openUrlService;
    private readonly IIdentityService _identityService;

    [ObservableProperty]
    private bool _isMock;

    [ObservableProperty]
    private bool _isValid;

    [ObservableProperty]
    private bool _isLogin;

    [ObservableProperty]
    private string _loginUrl;

    public LoginViewModel(
        IOpenUrlService openUrlService,
        IIdentityService identityService,
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
        : base(dialogService, navigationService, settingsService)
    {
        _settingsService = settingsService;
        _openUrlService = openUrlService;
        _identityService = identityService;

        UserName = new ValidatableObject<string>();
        Password = new ValidatableObject<string>();

        MockSignInCommand = new AsyncRelayCommand(MockSignInAsync);
        SignInCommand = new AsyncRelayCommand(SignInAsync);
        RegisterCommand = new AsyncRelayCommand(RegisterAsync);
        SettingsCommand = new AsyncRelayCommand(SettingsAsync);
        NavigateCommand = new AsyncRelayCommand<string>(NavigateAsync);
        ValidateCommand = new RelayCommand(() => Validate());

        InvalidateMock();
        AddValidations();
    }



    public ValidatableObject<string> UserName { get; private set; }
    public ValidatableObject<string> Password { get; private set; }

    public ICommand MockSignInCommand { get; }
    public ICommand SignInCommand { get; }
    public ICommand RegisterCommand { get; }
    public ICommand NavigateCommand { get; }
    public ICommand SettingsCommand { get; }
    public ICommand ValidateCommand { get; }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        if (query.ValueAsBool("Logout") == true)
        {
            PerformLogout();
        }
    }

    public override Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    private void PerformLogout()
    {
        var authIdToken = SettingsService.AuthIdToken;
        var logoutRequest = _identityService.CreateLogoutRequest(authIdToken);
        if (!string.IsNullOrEmpty(logoutRequest))
        {
            LoginUrl = logoutRequest;
        }
        if (SettingsService.UseMocks)
        {
            SettingsService.AuthAccessToken = string.Empty;
            SettingsService.AuthIdToken = string.Empty;
        }
        SettingsService.UseFakeLocation = false;
        UserName.Value = string.Empty;
        Password.Value = string.Empty;
    }

    private async Task MockSignInAsync()
    {
        await IsBusyFor(
            async () => {
                IsValid = true;
                bool isValid = Validate();
                bool isAuthenticated = false;
                if (isValid)
                {
                    try
                    {
                        await Task.Delay(10);
                        isAuthenticated = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[SignIn] Error signing in: {ex}");
                    }
                }
                else
                {
                    isValid = false;
                }
                if (isAuthenticated)
                {
                    _settingsService.AuthAccessToken = GlobalSettings.Instance.AuthToken;
                    await NavigationService.NavigateToAsync("//Home/MainPage");
                }
            });
    }

    private Task RegisterAsync()
    {
        return _openUrlService.OpenUrl(GlobalSettings.Instance.RegisterWebsite);
    }

    private async Task SignInAsync()
    {
        await IsBusyFor(
            async () => {
                await Task.Delay(10);
                LoginUrl = _identityService.CreateAuthorizationRequest();
                IsValid = true;
                IsLogin = true;
            });
    }

    private Task SettingsAsync()
    {
        return NavigationService.NavigateToAsync("Settings");
    }

    private bool Validate()
    {
        return UserName.Validate() && Password.Validate();
    }

    private void AddValidations()
    {
        UserName.Validations.Add(
            new IsNotNullOrEmptyRule<string> {
                ValidationMessage = AppResources.Login_Username_Required
            });
        Password.Validations.Add(
            new IsNotNullOrEmptyRule<string> {
                ValidationMessage = AppResources.Login_Password_Required
            });
    }

    private async Task NavigateAsync(string url)
    {
        var unescapedUrl = WebUtility.UrlDecode(url);
        if (unescapedUrl.Equals(GlobalSettings.Instance.LogoutCallback, StringComparison.OrdinalIgnoreCase))
        {
            _settingsService.AuthAccessToken = string.Empty;
            _settingsService.AuthIdToken = string.Empty;
            IsLogin = false;
            LoginUrl = _identityService.CreateAuthorizationRequest();
        }
        else if (unescapedUrl.Contains(GlobalSettings.Instance.Callback, StringComparison.OrdinalIgnoreCase))
        {
            var authResponse = new AuthorizeResponse(url);
            if (!string.IsNullOrWhiteSpace(authResponse.Code))
            {
                var userToken = await _identityService.GetTokenAsync(authResponse.Code);
                string accessToken = userToken.AccessToken;

                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    _settingsService.AuthAccessToken = accessToken;
                    _settingsService.AuthIdToken = authResponse.IdentityToken;
                    await NavigationService.NavigateToAsync("//Home/MainPage");
                }
            }
        }
    }

    private void InvalidateMock()
    {
        IsMock = _settingsService.UseMocks;
    }

}
