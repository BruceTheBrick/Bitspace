using System.Timers;

namespace Bitspace.Services.TimerService
{
    public class TimerService : ITimerService
    {
        public Timer Timer(int millis, ElapsedEventHandler callback)
        {
            var timer = new Timer(millis);
            timer.Enabled = true;
            timer.Elapsed += callback;
            return timer;
        }
    }
}