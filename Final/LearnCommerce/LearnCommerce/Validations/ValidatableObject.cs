/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/10/2023
 * Modified: 3/10/2023
 */

namespace LearnCommerce.Validations;

public class ValidatableObject<T> : ObservableObject, IValidity
{
    private bool _isValid;
    private IEnumerable<string> _errors;
    private T _value;

    public ValidatableObject ()
    {
        _isValid = true;
        _errors = Enumerable.Empty<string>();
    }

    public List<IValidationRule<T>> Validations { get; } = new();

    public bool IsValid
    {
        get => _isValid;
        private set => SetProperty(ref _isValid, value);
    }

    public IEnumerable<string> Errors
    {
        get => _errors;
        private set => SetProperty(ref _errors, value);
    }

    public T Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    public bool Validate ()
    {
        Errors = Validations?
            .Where(v => !v.Check(Value))?
            .Select(v => v.ValidationMessage)?
            .ToArray()
            ?? Enumerable.Empty<string>();
        IsValid = !Errors.Any();
        return IsValid;
    }
}
