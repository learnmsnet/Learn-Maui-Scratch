/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Services.Locations;

public class LocationService : ILocationService
{
    private readonly IRequestService _request;
    private const string ApiUrlBase = "l/api/v1/locations";
    public LocationService (
        IRequestService requestService)
    {
        _request = requestService;
    }

    public async Task UpdateUserLocation (
        UserLocation newLocation,
        string token)
    {
        var uri = API.Location.UpdateUserLocation(
            UriHelper.CombineUri(
                GlobalSettings.Instance.GatewayMarketingEndpoint, ApiUrlBase));
        await _request.PostAsync(uri, newLocation, token);
    }
}
