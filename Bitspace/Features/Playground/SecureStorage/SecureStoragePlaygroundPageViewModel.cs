using Bitespace.Core;
using CommunityToolkit.Mvvm.Input;

namespace Bitspace.Features.SecureStorage;

public partial class SecureStoragePlaygroundPageViewModel : BasePlaygroundPageViewModel
{
    private readonly ILegacySecureStorage _legacySecureStorage;

    private static readonly string Alias = $"{AppInfo.PackageName}.xamarinessentials";
    public SecureStoragePlaygroundPageViewModel(
        ILegacySecureStorage legacySecureStorage,
        IBaseService baseService)
        : base(baseService)
    {
        _legacySecureStorage = legacySecureStorage;
    }

    public string Key { get; set; }
    public string Value { get; set; }
    public string FetchedValue { get; set; }
    public bool WasValueFetched { get; set; }

    [RelayCommand]
    private Task SetValue()
    {
        return Task.CompletedTask;
        // return Xamarin.Essentials.SecureStorage.SetAsync(Key, Value);
    }

    [RelayCommand]
    private async Task FetchValue()
    {
        FetchedValue = await _legacySecureStorage.GetAsync(Key);
        WasValueFetched = !string.IsNullOrWhiteSpace(FetchedValue);
    }
}