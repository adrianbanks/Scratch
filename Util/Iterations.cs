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
            using var timer = CreateTimer(timingMethod);
            
            for (var i = 1; i <= numberOfIterations; i++)
            {
                action();

                if (i < numberOfIterations)
                {
                    betweenEachAction?.Invoke();
                }
            }
        }

        private static IDisposable CreateTimer(TimingMethod timingMethod)
        {
            return timingMethod switch
            {
                TimingMethod.WallClock => new MyWallTimer(),
                TimingMethod.CPU => new MyCpuTimer(),
                _ => new NullTimer()
            };
        }

        private sealed class NullTimer : IDisposable
        {
            public void Dispose()
            {}
        }
    }
}
