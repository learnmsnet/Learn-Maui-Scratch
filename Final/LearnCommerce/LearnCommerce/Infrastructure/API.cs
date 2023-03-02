/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/28/2023
 * Modified: 2/28/2023
 */

namespace LearnCommerce.Infrastructure;

public class API
{
    public static class Location
    {
        public static string UpdateUserLocation (
            string baseUri) => $"{baseUri}/UpdateUserLocation";
    }
}
