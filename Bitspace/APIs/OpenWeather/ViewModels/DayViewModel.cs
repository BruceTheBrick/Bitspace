using Humanizer;

namespace Bitspace.APIs;

public class DayViewModel
{
    public DayViewModel()
    {
        ForecastItems = new List<ForecastItemViewModel>();
    }

    public DayViewModel(DateTime dateTime, IList<ForecastItemViewModel> forecastItems)
    {
        DateTime = dateTime;
        ForecastItems = forecastItems;
    }

    public DateTime DateTime { get; }
    public IList<ForecastItemViewModel> ForecastItems { get; }
    public double Temperature { get; set; }
    public double WindSpeed { get; set; }
    public double Humidity { get; set; }
    public double RainChance { get; set; }
    public string Description { get; set; }

    public void AddForecastItem(ForecastItemViewModel item)
    {
        ForecastItems.Add(item);
        CalculateAverages();
    }

    private void CalculateAverages()
    {
        var temp = 0.0;
        var windSpeed = 0.0;
        var humidity = 0.0;
        var rainChance = 0.0;
        var descriptions = new Dictionary<string, int>();
        foreach (var item in ForecastItems)
        {
            temp += item.Temperature;
            windSpeed += item.WindSpeed * 3.6;
            humidity += item.Humidity;
            rainChance += item.RainChance * 100;
            if (descriptions.ContainsKey(item.Description))
            {
                var element = descriptions.First(x => x.Key == item.Description);
                descriptions.Remove(element.Key);
                descriptions.Add(element.Key, element.Value + 1);
            }
            else
            {
                descriptions.Add(item.Description, 1);
            }
        }

        Temperature = Math.Round(temp / ForecastItems.Count);
        WindSpeed = Math.Round(windSpeed / ForecastItems.Count);
        Humidity = Math.Round(humidity / ForecastItems.Count);
        RainChance = Math.Round(rainChance / ForecastItems.Count);

        SetDescription(descriptions);
    }

    private void SetDescription(IDictionary<string, int> descriptions)
    {
        var counts = descriptions.Values;
        var sorted = counts.OrderByDescending(x => x);
        var desc = descriptions.First(x => x.Value == sorted.First());
        Description = desc.Key.Humanize();
    }
}