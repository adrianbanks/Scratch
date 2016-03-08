using System;
using System.Diagnostics;

namespace Scratch
{
    /// <summary>
    /// A timer that times the elapsed wall time.
    /// </summary>
    /// <seealso cref="MyCpuTimer"/>
    public sealed class MyWallTimer : IDisposable
    {
        private readonly string message;
        private readonly Stopwatch stopwatch;
        private bool disposed;

        /// <summary>
        /// Creates a new instance that will output the wall time to the console.
        /// </summary>
        public MyWallTimer() : this(null)
        {}

        /// <summary>
        /// Creates a new instance with a message that will be output
        /// to the console along with the CPU time.
        /// </summary>
        public MyWallTimer(string message)
        {
            this.message = message;
            stopwatch = Stopwatch.StartNew();
        }

        ~MyWallTimer()
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
                stopwatch.Stop();

                if (disposing)
                {
                    Console.WriteLine();

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.Write("{0} - ", message);
                    }

                    Console.WriteLine("Elapsed Time: {0}", stopwatch.Elapsed);
                    disposed = true;
                }
            }
        }
    }
}
