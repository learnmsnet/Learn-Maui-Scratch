/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Services.Request;

public interface IRequestService
{
    Task<TResult> GetAsync<TResult> (string uri, string token = "");
    Task<TResult> PostAsync<TResult> (string uri, TResult data, string token = "", string header = "");
    Task<TResult> PostAsync<TResult> (string uri, string data, string clientId, string clientSecret);
    Task<TResult> PutAsync<TResult> (string uri, TResult data, string token = "", string header = "");
    Task DeleteAsync (string uri, string token = "");
}
