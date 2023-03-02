/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Exceptions;

public class ServiceAuthenticationException : Exception
{
    public string Content { get; }
    public ServiceAuthenticationException () { }
    public ServiceAuthenticationException (string content)
    {
        Content = content;
    }
}
