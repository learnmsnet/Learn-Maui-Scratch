/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Exceptions;

public class HttpRequestExceptionEx : HttpRequestException
{
    public HttpStatusCode HttpCode { get; }
    public HttpRequestExceptionEx (HttpStatusCode code) : this(code, null, null) { }
    public HttpRequestExceptionEx (HttpStatusCode code, string message) : this(code, message, null) { }
    public HttpRequestExceptionEx (HttpStatusCode code, string message, Exception inner) : base(message, inner)
    {
        HttpCode = code;
    }
}
