using System.Timers;

namespace Bitspace.Core
{
    public interface ITimerService
    {
        public Timer GetTimer(int millis, ElapsedEventHandler callback);
    }
}