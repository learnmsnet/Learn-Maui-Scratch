/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/15/2023
 * Modified: 3/15/2023
 */

namespace LearnCommerce.Controls;

public class ProductSearchHandler : SearchHandler
{
    private readonly INavigationService _navigationService;

    public ProductSearchHandler(
        INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public Type SelectedItemNavigationTarget { get; set; }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);
        if (string.IsNullOrWhiteSpace(oldValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = null;
        }
    }

    protected override async void OnItemSelected(
        object item)
    {
        base.OnItemSelected(item);
        await Task.Delay(100);
        await _navigationService.NavigateToAsync($"{nameof(ProductPage)}",
            new Dictionary<string, object> { { "ProductId", 1 } });
    }
}
