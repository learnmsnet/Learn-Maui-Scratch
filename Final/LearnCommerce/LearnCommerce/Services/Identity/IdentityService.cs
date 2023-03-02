/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly IRequestService _request;
    private string _codeVerifier;

    public IdentityService (
        IRequestService requestService)
    {
        _request = requestService;
    }

    public string CreateAuthorizationRequest ()
    {
        // Create URI to authorization endpoint
        var authorizeRequest = new AuthorizeRequest(GlobalSettings.Instance.AuthorizeEndpoint);

        // Dictionary with values for the authorize request
        var dic = new Dictionary<string, string>
        {
            { "client_id", GlobalSettings.Instance.ClientId },
            { "client_secret", GlobalSettings.Instance.ClientSecret },
            { "response_type", "code id_token" },
            { "scope", "openid profile basket orders offline_access" },
            { "redirect_uri", GlobalSettings.Instance.Callback },
            { "nonce", Guid.NewGuid().ToString("N") },
            { "code_challenge", CreateCodeChallenge() },
            { "code_challenge_method", "S256" }
        };

        // Add CSRF token to protect against cross-site request forgery attacks.
        var currentCSRFToken = Guid.NewGuid().ToString("N");
        dic.Add("state", currentCSRFToken);

        var authorizeUri = authorizeRequest.Create(dic);
        return authorizeUri;
    }

    public string CreateLogoutRequest (string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return string.Empty;
        }

        var settings = GlobalSettings.Instance;
        var (endpoint, callback) =
            (settings.LogoutEndpoint, settings.LogoutCallback);

        return $"{endpoint}?id_token_hint={token}&post_logout_redirect_uri={callback}";
    }

    public async Task<UserToken> GetTokenAsync (string code)
    {
        string data = string.Format(
            "grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}",
            code,
            WebUtility.UrlEncode(GlobalSettings.Instance.Callback),
            _codeVerifier);
        var token = await _request.PostAsync<UserToken>(
            GlobalSettings.Instance.TokenEndpoint,
            data,
            GlobalSettings.Instance.ClientId,
            GlobalSettings.Instance.ClientSecret);
        return token;
    }

    private string CreateCodeChallenge ()
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] buffer = new byte[64];
        rng.GetBytes(buffer);
        _codeVerifier = ByteArrayToString(buffer);
        var hash = SHA256.HashData(buffer);
        return Base64Url.Encode(hash);
    }

    private static string ByteArrayToString (byte[] array)
    {
        var hex = new StringBuilder(array.Length * 2);
        foreach (byte b in array)
        {
            hex.AppendFormat("{0:x2}", b);
        }
        return hex.ToString();
    }
}
