using System.Collections.Generic;
using System.Linq;
using Bitspace.APIs;

namespace Bitspace.Tests.Extensions;

public static class ForecastListObjectResponseExtensions
{
    public static ForecastItemViewModel ToForecastItemViewModel(this ForecastListObjectResponse response)
    {
        return new ForecastItemViewModel(response);
    }

    public static ForecastItemViewModel[] ToForecastItemViewModelArray(this ForecastListObjectResponse[] responses)
    {
        return responses.Select(item => new ForecastItemViewModel(item)).ToArray();
    }
        
    public static ForecastItemViewModel[] ToForecastItemViewModelArray(this IList<ForecastListObjectResponse> responses)
    {
        return responses.Select(item => new ForecastItemViewModel(item)).ToArray();
    }
}