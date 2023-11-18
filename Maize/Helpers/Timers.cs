using System.Diagnostics;

namespace Maize.Helpers
{
    public class Timers
    {
        public static void ApiStopWatchCheck(Stopwatch apiSw)
        {
            apiSw.Stop();
            TimeSpan elapsed = apiSw.Elapsed;
            TimeSpan maxDelay = TimeSpan.FromSeconds(1);

            if (elapsed < maxDelay)
            {
                TimeSpan remainingDelay = maxDelay - elapsed;

                if (remainingDelay > TimeSpan.Zero)
                {
                     Thread.Sleep(remainingDelay);
                }
            }
        }
    }
}
