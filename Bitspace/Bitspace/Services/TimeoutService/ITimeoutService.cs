using System;

namespace Bitspace.Services.TimeoutService;

public interface ITimeoutService
{
    public int? ExpiryMinutes { set; }

    public bool IsExpired();
    public bool IsExpired(DateTime dateTimeLastUpdate, int expiryMinutes);
    public void Update();
}