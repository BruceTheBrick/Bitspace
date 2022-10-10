using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services
{
    public interface IGeocodeService
    {
        public Task<ReverseGeocodeViewModel> GetCurrentLocationName();
    }
}