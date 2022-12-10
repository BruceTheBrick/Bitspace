using System.Threading.Tasks;

namespace Bitspace.Core
{
    public interface IRemoteConfigService
    {
        public bool IsEnabled(string featureName);
        public string GetValue(string featureName);
        public Task FetchAndActivate();
    }
}
