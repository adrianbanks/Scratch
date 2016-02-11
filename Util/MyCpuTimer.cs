using System;

namespace Scratch
{
    /// <summary>
    /// A timer that times the elapsed CPU time.
    /// </summary>
    /// <remarks>
    /// This uses the current application domain timer
    /// which gets paused when the threads are not running.
    /// </remarks>
    /// <seealso cref="MyWallTimer"/>
    public sealed class MyCpuTimer : IDisposable
    {
        private readonly string message;
        private readonly TimeSpan cpuTime;
        private bool disposed;

        /// <summary>
        /// Creates a new instance that will output the CPU time to the console.
        /// </summary>
        public MyCpuTimer() : this(null)
        {}

        /// <summary>
        /// Creates a new instance with a message that will be output
        /// to the console along with the CPU time.
        /// </summary>
        public MyCpuTimer(string message)
        {
            AppDomain.MonitoringIsEnabled = true;
            this.message = message;
            this.cpuTime = AppDomain.CurrentDomain.MonitoringTotalProcessorTime;
        }

        ~MyCpuTimer()
        {
            Dispose(false);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                TimeSpan elapsed = AppDomain.CurrentDomain.MonitoringTotalProcessorTime - cpuTime;

                if (disposing)
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.Write("{0} - ", message);
                    }

                    Console.WriteLine("CPU Time: {0}", elapsed);
                    disposed = true;
                }
            }
        }
    }
}
