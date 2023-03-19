/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/10/2023
 * Modified: 3/10/2023
 */

namespace LearnCommerce.Validations.Interfaces;

public interface IValidationRule<T>
{
    string ValidationMessage { get; set; }
    bool Check (T value);
}
