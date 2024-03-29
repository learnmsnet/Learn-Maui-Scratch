/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 3/11/2023
 */

namespace LearnCommerce.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(
        LoginViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}