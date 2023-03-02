/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/1/2023
 * Modified: 3/1/2023
 */

namespace LearnCommerce.ViewModels;

public class OnBoardingViewModel : BaseViewModel
{
    public OnBoardingViewModel (
        IDialogService dialogService,
        INavigationService navigationService,
        ISettingsService settingsService)
        : base(dialogService, navigationService, settingsService)
    {
        FinishOnBoardingCommand = new AsyncRelayCommand(FinishOnBoarding);
    }

    public IAsyncRelayCommand FinishOnBoardingCommand { get; }

    private async Task FinishOnBoarding ()
    {
        await NavigationService.NavigateToAsync("//Login");
    }

    public ObservableCollection<OnBoardingItem> OnBoardingSteps { get; set; } = new ObservableCollection<OnBoardingItem>()
    {
        new OnBoardingItem("welcome",
            AppResources.OnBoarding_Welcome_Title,
            AppResources.OnBoarding_Welcome_Details),
        new OnBoardingItem("security",
            AppResources.OnBoarding_Safety_Title,
            AppResources.OnBoarding_Safety_Details)
    };
}
