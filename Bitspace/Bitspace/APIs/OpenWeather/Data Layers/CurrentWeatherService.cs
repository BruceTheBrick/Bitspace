using System;
using System.Threading.Tasks;
using Bitspace.APIs.OpenWeather.Models;
using Bitspace.APIs.OpenWeather.Response_Models;
using Bitspace.Data_Layers;

namespace Bitspace.APIs.OpenWeather.Data_Layers;

public class CurrentWeatherService : BaseDataLayer, ICurrentWeatherService
{
    private readonly IOpenWeatherAPI _openWeatherApi;
    private CurrentWeatherResponse _currentWeatherResponse;
    private CurrentWeatherViewModel _currentWeatherViewModel;

    public CurrentWeatherService(IOpenWeatherAPI openWeatherApi)
    {
        _openWeatherApi = openWeatherApi;
    }

    public async Task<CurrentWeatherViewModel> GetCurrentWeather()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        InitCurrentWeatherViewModel();
        return _currentWeatherViewModel;
    }

    public async Task<string> GetSuburb()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Name;
    }

    public async Task<double> GetTemperature()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        return Math.Round(_currentWeatherResponse.Main.Temperature, 2);
    }

    public async Task<double> GetHumidity()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Main.Humidity;
    }

    public async Task<double> GetWindSpeed()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        return Math.Round(_currentWeatherResponse.Wind.Speed, 2);
    }

    public async Task<double> GetPressure()
    {
        if (IsExpired())
        {
            await FetchCurrentWeather();
        }

        return _currentWeatherResponse.Main.Pressure;
    }

    private async Task FetchCurrentWeather()
    {
        _currentWeatherResponse = await _openWeatherApi.GetCurrentWeather();
        UpdateDateTimeLastUpdate();
    }

    private void InitCurrentWeatherViewModel()
    {
        _currentWeatherViewModel = new CurrentWeatherViewModel
        {
            Suburb = _currentWeatherResponse.Name,
            Temperature = _currentWeatherResponse.Main.Temperature,
            Humidity = _currentWeatherResponse.Main.Humidity,
            Pressure = _currentWeatherResponse.Main.Pressure,
            WindSpeed = _currentWeatherResponse.Wind.Speed,
        };
    }
}