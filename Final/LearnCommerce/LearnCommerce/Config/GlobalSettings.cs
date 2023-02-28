/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/27/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.Config;

public class GlobalSettings
{
    public const string AzureTag = "Azure";
    public const string MockTag = "Mock";
    public const string DefaultEndpoint = "http://YOUR_IP_OR_DNS_NAME"; // i.e.: "http://YOUR_IP" or "http://example.com"

    private string _baseIdentityEndpoint;
    private string _baseGatewayShoppingEndpoint;
    private string _baseGatewayMarketingEndpoint;

    public GlobalSettings ()
    {
        AuthToken = "INSERT AUTHENTICATION TOKEN";
        BaseIdentityEndpoint = DefaultEndpoint;
        BaseGatewayShoppingEndpoint = DefaultEndpoint;
        BaseGatewayMarketingEndpoint = DefaultEndpoint;
    }

    public static GlobalSettings Instance { get; } = new();

    public string BaseIdentityEndpoint
    {
        get => _baseIdentityEndpoint;
        set {
            _baseIdentityEndpoint = value;
            UpdateEndpoint(_baseIdentityEndpoint);
        }
    }

    public string BaseGatewayShoppingEndpoint
    {
        get => _baseGatewayShoppingEndpoint;
        set {
            _baseGatewayShoppingEndpoint = value;
            UpdateGatewayAdEndpoint(_baseGatewayShoppingEndpoint);
        }
    }

    public string BaseGatewayMarketingEndpoint
    {
        get => _baseGatewayMarketingEndpoint;
        set {
            _baseGatewayMarketingEndpoint = value;
            UpdateGatewayMarketingEndpoint(_baseGatewayMarketingEndpoint);
        }
    }

    public string ClientId { get; } = "mobile";

    public string ClientSecret { get; } = "secret";

    public string AuthToken { get; set; }

    public string RegisterWebsite { get; set; }

    public string AuthorizeEndpoint { get; set; }

    public string UserInfoEndpoint { get; set; }

    public string TokenEndpoint { get; set; }

    public string LogoutEndpoint { get; set; }

    public string Callback { get; set; }

    public string LogoutCallback { get; set; }

    public string GatewayAdEndpoint { get; set; }

    public string GatewayMarketingEndpoint { get; set; }

    private void UpdateEndpoint (string endpoint)
    {
        RegisterWebsite = $"{endpoint}/Account/Register";
        LogoutCallback = $"{endpoint}/Account/Redirecting";

        var connectBaseEndpoint = $"{endpoint}/connect";
        AuthorizeEndpoint = $"{connectBaseEndpoint}/authorize";
        UserInfoEndpoint = $"{connectBaseEndpoint}/userinfo";
        TokenEndpoint = $"{connectBaseEndpoint}/token";
        LogoutEndpoint = $"{connectBaseEndpoint}/endsession";

        var baseUri = GlobalSettings.ExtractBaseUri(endpoint);
        Callback = $"{baseUri}/xamarincallback";
    }

    private void UpdateGatewayAdEndpoint (string endpoint)
    {
        GatewayAdEndpoint = endpoint;
    }

    private void UpdateGatewayMarketingEndpoint (string endpoint)
    {
        GatewayMarketingEndpoint = endpoint;
    }

    private static string ExtractBaseUri (string endpoint)
    {
        try
        {
            var uri = new Uri(endpoint);
            var baseUri = uri.GetLeftPart(UriPartial.Authority);

            return baseUri;
        }
        catch (Exception ex)
        {
            _ = ex;
            return DefaultEndpoint;
        }
    }
}
