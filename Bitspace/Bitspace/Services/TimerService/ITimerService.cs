using System;
using System.Timers;

namespace Bitspace.Services.TimerService
{
    public interface ITimerService
    {
        public Timer Timer(int millis, ElapsedEventHandler callback);
    }
}