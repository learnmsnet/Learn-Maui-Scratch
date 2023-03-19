/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/10/2023
 * Modified: 3/10/2023
 */

namespace LearnCommerce.Validations;

public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
{
    public string ValidationMessage { get; set; }

    public bool Check (T value) =>
        value is string str &&
        !string.IsNullOrWhiteSpace(str);
}
