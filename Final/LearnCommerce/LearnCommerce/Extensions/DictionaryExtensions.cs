/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 3/10/2023
 * Modified: 3/10/2023
 */

namespace LearnCommerce.Extensions;

public static class DictionaryExtensions
{
    public static bool ValueAsBool (
        this IDictionary<string, object> dictionary,
        string key,
        bool defaultValue = false) =>
        dictionary.TryGetValue(key, out object value) && value is bool dictValue
        ? dictValue
        : defaultValue;


}
