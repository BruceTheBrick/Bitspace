namespace Bitspace.Services.RemoteConfig
{
    public interface IRemoteConfigService
    {
        public bool IsEnabled(string featureName);
        public string GetValue(string featureName);
        public void Update();
        public bool Exists(string featureName);
    }
}
