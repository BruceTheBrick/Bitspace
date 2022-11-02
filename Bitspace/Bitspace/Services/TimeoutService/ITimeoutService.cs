using System;

namespace Bitspace.Services
{
    public interface ITimeoutService
    {
        public int? ExpiryMinutes { set; }

        public bool IsExpired();
        public bool IsExpired(DateTime dateTimeLastUpdate);
        public bool IsExpired(DateTime dateTimeLastUpdate, int expiryMinutes);
        public void Update();
    }
}