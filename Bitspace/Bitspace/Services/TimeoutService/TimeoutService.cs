using System;

namespace Bitspace.Services;

public class TimeoutService : ITimeoutService
{
    public DateTime DateTimeLastUpdate { get; set; }
    public int? ExpiryMinutes { get; set; }

    public bool IsExpired()
    {
        if (ExpiryMinutes == null)
        {
            return false;
        }

        if (DateTimeLastUpdate.Equals(DateTime.MinValue))
        {
            return true;
        }

        return (DateTime.Now - DateTimeLastUpdate).Minutes > ExpiryMinutes;
    }

    public bool IsExpired(DateTime dateTimeLastUpdate)
    {
        if (ExpiryMinutes == null)
        {
            return false;
        }

        if (dateTimeLastUpdate == DateTime.MinValue)
        {
            return true;
        }

        return (DateTime.Now - dateTimeLastUpdate).Minutes > ExpiryMinutes;
    }

    public bool IsExpired(DateTime dateTimeLastUpdate, int expiryMinutes)
    {
        if (dateTimeLastUpdate.Equals(DateTime.MinValue))
        {
            return true;
        }

        return (DateTime.Now - dateTimeLastUpdate).Minutes > expiryMinutes;
    }

    public void Update()
    {
        DateTimeLastUpdate = DateTime.Now;
    }
}