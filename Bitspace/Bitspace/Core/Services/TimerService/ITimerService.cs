using System.Timers;
using Timer = System.Timers.Timer;

namespace Bitspace.Core;

public interface ITimerService
{
    public Timer GetTimer(int millis, ElapsedEventHandler callback);
}