using System;

namespace Bitspace.Data_Layers;

public class BaseDataLayer
{
    protected const int EXPIRY_MINS = 5;

    protected DateTime DateTimeLastUpdate;

    protected bool IsExpired()
    {
        if (DateTimeLastUpdate.Equals(DateTime.MinValue))
        {
            return true;
        }

        var elapsed = DateTime.Now - DateTimeLastUpdate;
        return elapsed.Minutes > EXPIRY_MINS;
    }

    protected void UpdateDateTimeLastUpdate()
    {
        DateTimeLastUpdate = DateTime.Now;
    }
}