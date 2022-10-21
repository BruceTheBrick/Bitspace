using System.Threading.Tasks;
using Prism.Navigation;

namespace Bitspace.Services
{
    public interface IAlertService
    {
        public Task<INavigationResult> Snackbar(string message);
        public Task Toast(string message);
        public Task Toast(string message, int milliseconds);
    }
}