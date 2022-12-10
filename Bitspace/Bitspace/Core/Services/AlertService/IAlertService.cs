using System.Threading.Tasks;
using Prism.Navigation;

namespace Bitspace.Core
{
    public interface IAlertService
    {
        public Task<INavigationResult> Snackbar(string message);
        public Task Toast(string message);
        public Task Toast(string message, int milliseconds);
    }
}