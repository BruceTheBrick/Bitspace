using System.Timers;

namespace Bitspace.Core
{
    public interface ITimerService
    {
        public Timer Timer(int millis, ElapsedEventHandler callback);
    }
}