using System;

namespace Scratch
{
    /// <summary>
    /// A class that can monitor a memory difference over a specified period.
    /// </summary>
    public sealed class MyMemoryDiff : IDisposable
    {
        private readonly long memoryAllocated;
        private readonly long memoryInUse;
        private readonly string message;
        private readonly MyMemory start;
        private bool disposed;

        /// <summary>
        /// Creates a new instance that will output the memory difference to the console.
        /// </summary>
        public MyMemoryDiff() : this(null)
        {}

        /// <summary>
        /// Creates a new instance with a message that will be output
        /// to the console along with the memory difference.
        /// </summary>
        public MyMemoryDiff(string message)
        {
            AppDomain.MonitoringIsEnabled = true;
            var domain = AppDomain.CurrentDomain;
            memoryAllocated = domain.MonitoringTotalAllocatedMemorySize;
            memoryInUse = domain.MonitoringSurvivedMemorySize;
            this.message = message;
            start = MyMemory.Now();
        }

        ~MyMemoryDiff()
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
                if (disposing)
                {
                    var domain = AppDomain.CurrentDomain;
                    var allocated = domain.MonitoringTotalAllocatedMemorySize - memoryAllocated;
                    var survived = domain.MonitoringSurvivedMemorySize - memoryInUse;
                    var end = MyMemory.Now();

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine($@"{message} - ");
                    }

                    Console.WriteLine($@"Memory Difference = {end.CurrentMemory - start.CurrentMemory:N0} bytes");
                    Console.WriteLine($@"Total Allocated = {allocated:N0} bytes, Survived GCs = {survived:N0} bytes");
                    disposed = true;
                }
            }
        }
    }
 }
