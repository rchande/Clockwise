using System;
using System.Threading.Tasks;
using Pocket;

namespace Clockwise
{
    public static class ClockExtensions
    {
        public static void Schedule(
            this IClock clock,
            Action<IClock> action,
            TimeSpan? after) =>
            clock.Schedule(action, clock.Now() + after);

        public static void Schedule(
            this IClock clock,
            Func<IClock, Task> action,
            TimeSpan? after) =>
            clock.Schedule(action, clock.Now() + after);

        public static async Task Wait(
            this IClock clock,
            TimeSpan timespan)
        {
            if (clock == null)
            {
                throw new ArgumentNullException(nameof(clock));
            }

            using (new OperationLogger(message: $"Waiting {timespan}", category: "Clock", logOnStart: true))
            {
                switch (clock)
                {
                    case VirtualClock c:
                        await c.AdvanceBy(timespan);
                        break;
                    default:
                        await Task.Delay(timespan);
                        break;
                }
            }
        }
    }
}
