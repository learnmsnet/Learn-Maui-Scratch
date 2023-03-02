/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 3/1/2023
 */

namespace LearnCommerce.Pages;

public partial class OnBoardingPage : ContentPage
{
    public OnBoardingPage (
        OnBoardingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}