namespace Bitspace.Services
{
    public interface IDeviceInformationService
    {
        bool IsiOS { get; }
        bool IsAndroid { get; }
    }
}
