using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitspace.Services
{
    public interface IAlertService
    {
        public Task<bool> Snackbar(string message);
        public Task<bool> Snackbar(string message, IEnumerable<Func<Task>> actions);
        public Task Toast(string message);
        public Task Toast(string message, int milliseconds);
    }
}