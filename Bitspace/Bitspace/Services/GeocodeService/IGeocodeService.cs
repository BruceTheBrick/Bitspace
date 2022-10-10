using System.Threading.Tasks;
using Bitspace.APIs;

namespace Bitspace.Services.GeocodeService
{
    public interface IGeocodeService
    {
        public Task<ReverseGeocodeViewModel> GetCurrentLocationName();
    }
}