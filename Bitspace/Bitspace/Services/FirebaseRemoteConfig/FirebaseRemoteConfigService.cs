using System.Threading.Tasks;

namespace Bitspace.Services.FirebaseRemoteConfig
{
    public class FirebaseRemoteConfigService : IFirebaseRemoteConfig
    {
        public async Task<bool> IsEnabled(string featureName)
        {
            return true;
        }
    }
}
