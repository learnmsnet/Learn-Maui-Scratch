/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/27/2023
 * Modified: 2/27/2023
 */

namespace LearnCommerce.Services.Settings;

public class SettingsService : ISettingsService
{
    private const string AccessToken = "access_token";
    private const string IdToken = "id_token";
    private const string IdUseMocks = "use_mocks";
    private const string IdIdentityBase = "url_base";
    private const string IdGatewayMarketingBase = "url_marketing";
    private const string IdGatewayShoppingBase = "url_shopping";
    private const string IdUseFakeLocation = "use_fake_location";
    private const string IdLatitude = "latitude";
    private const string IdLongitude = "longitude";
    private const string IdAllowGpsLocation = "allow_gps_location";
    private readonly string AccessTokenDefault = string.Empty;
    private readonly string IdTokenDefault = string.Empty;
    private readonly bool UseMocksDefault = true;
    private readonly bool UseFakeLocationDefault = false;
    private readonly bool AllowGpsLocationDefault = false;
    private readonly double FakeLatitudeDefault = 44.647719910353615d;
    private readonly double FakeLongitudeDefault = -63.57950096963488d;
    private readonly string UrlIdentityDefault = GlobalSettings.Instance.BaseIdentityEndpoint;
    private readonly string UrlGatewayMarketingDefault = GlobalSettings.Instance.BaseGatewayMarketingEndpoint;
    private readonly string UrlGatewayShoppingDefault = GlobalSettings.Instance.BaseGatewayShoppingEndpoint;

    public string AuthAccessToken
    {
        get => Preferences.Get(AccessToken, AccessTokenDefault);
        set => Preferences.Set(AccessToken, value);
    }

    public string AuthIdToken
    {
        get => Preferences.Get(IdToken, IdTokenDefault);
        set => Preferences.Set(IdToken, value);
    }

    public bool UseMocks
    {
        get => Preferences.Get(IdUseMocks, UseMocksDefault);
        set => Preferences.Set(IdUseMocks, value);
    }

    public string IdentityEndpointBase
    {
        get => Preferences.Get(IdIdentityBase, UrlIdentityDefault);
        set => Preferences.Set(IdIdentityBase, value);
    }

    public string GatewayShoppingEndpointBase
    {
        get => Preferences.Get(IdGatewayShoppingBase, UrlGatewayShoppingDefault);
        set => Preferences.Set(IdGatewayShoppingBase, value);
    }

    public string GatewayMarketingEndpointBase
    {
        get => Preferences.Get(IdGatewayMarketingBase, UrlGatewayMarketingDefault);
        set => Preferences.Set(IdGatewayMarketingBase, value);
    }

    public bool UseFakeLocation
    {
        get => Preferences.Get(IdUseFakeLocation, UseFakeLocationDefault);
        set => Preferences.Set(IdUseFakeLocation, value);
    }

    public string Latitude
    {
        get => Preferences.Get(IdLatitude, FakeLatitudeDefault.ToString());
        set => Preferences.Set(IdLatitude, value);
    }

    public string Longitude
    {
        get => Preferences.Get(IdLongitude, FakeLongitudeDefault.ToString());
        set => Preferences.Set(IdLongitude, value);
    }

    public bool AllowGpsLocation
    {
        get => Preferences.Get(IdAllowGpsLocation, AllowGpsLocationDefault);
        set => Preferences.Set(IdAllowGpsLocation, value);
    }

    public bool ContainsKey (string key) => Preferences.ContainsKey(key);
    public bool Get (string key, bool defaultValue) => Preferences.Get(key, defaultValue);
    public string Get (string key, string defaultValue) => Preferences.Get(key, defaultValue);
    public void Set (string key, string value) => Preferences.Set(key, value);
    public void Set (string key, bool value) => Preferences.Set(key, value);
}
