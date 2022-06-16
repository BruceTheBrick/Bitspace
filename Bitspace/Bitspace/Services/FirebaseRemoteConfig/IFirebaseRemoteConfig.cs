using System.Threading.Tasks;

namespace Bitspace.Services.FirebaseRemoteConfig
{
    public interface IFirebaseRemoteConfig
    {
        public Task<bool> IsEnabled(string featureName);
    }
}
