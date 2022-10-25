using System.Threading.Tasks;

namespace Bitspace.Services
{
    public interface IRemoteConfigService
    {
        public Task Initialize();
        public bool IsEnabled(string featureName);
        public string GetValue(string featureName);
        public Task FetchAndActivate();
    }
}
