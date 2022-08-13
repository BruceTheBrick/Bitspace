﻿namespace Bitspace.APIs.OpenWeather.Request_Models;

public class CurrentWeatherRequest
{
    public CurrentWeatherRequest(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}