/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Services.Identity;

public interface IIdentityService
{
    string CreateAuthorizationRequest ();
    string CreateLogoutRequest (string token);
    Task<UserToken> GetTokenAsync (string code);
}
