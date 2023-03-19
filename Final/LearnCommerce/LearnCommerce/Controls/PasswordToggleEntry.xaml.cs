/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/11/2023
 * Modified: 3/11/2023
 */

namespace LearnCommerce.Controls;

public partial class PasswordToggleEntry : ContentView
{
    public static readonly BindableProperty PlaceholderProperty =
    BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(PasswordToggleEntry));

    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(PasswordToggleEntry),
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty HidePasswordProperty =
        BindableProperty.Create(nameof(HidePassword), typeof(bool), typeof(PasswordToggleEntry),
            defaultValue: true);

    public static readonly BindableProperty HidePasswordColorProperty =
        BindableProperty.Create(nameof(HidePasswordColor), typeof(Color), typeof(PasswordToggleEntry),
            defaultValue: Colors.LightGray);
    public PasswordToggleEntry()
    {
        InitializeComponent();
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool HidePassword
    {
        get => (bool)GetValue(HidePasswordProperty);
        set => SetValue(HidePasswordProperty, value);
    }

    public Color HidePasswordColor
    {
        get => (Color)GetValue(HidePasswordColorProperty);
        set => SetValue(HidePasswordColorProperty, value);
    }

    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        HidePassword = !HidePassword;
    }
}