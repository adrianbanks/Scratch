using System;

namespace Scratch
{
    internal enum TimingMethod
    {
        None,
        WallClock,
        CPU
    }

    internal static class Iterations
    {
        /// <summary>
        /// Runs an action a given number of times.
        /// </summary>
        public static void Run(int numberOfIterations, Action action, Action betweenEachAction = null, TimingMethod timingMethod = TimingMethod.None)
        {
            using (var timer = CreateTimer(timingMethod))
            {
                for (int i = 1; i <= numberOfIterations; i++)
                {
                    action();

                    if (i < numberOfIterations)
                    {
                        betweenEachAction?.Invoke();
                    }
                }
            }
        }

        private static IDisposable CreateTimer(TimingMethod timingMethod)
        {
            switch (timingMethod)
            {
                case TimingMethod.WallClock:
                    return new MyWallTimer();
                case TimingMethod.CPU:
                    return new MyCpuTimer();
                default:
                    return new NullTimer();
            }
        }

        private class NullTimer : IDisposable
        {
            public void Dispose()
            {}
        }
    }
}
