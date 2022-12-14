using System.Timers;

namespace Bitspace.Core
{
    public class TimerService : ITimerService
    {
        public Timer GetTimer(int millis, ElapsedEventHandler callback)
        {
            var timer = new Timer(millis);
            timer.Enabled = true;
            timer.Elapsed += callback;
            return timer;
        }
    }
}