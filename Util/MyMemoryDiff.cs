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
            AppDomain domain = AppDomain.CurrentDomain;
            memoryAllocated = domain.MonitoringTotalAllocatedMemorySize;
            memoryInUse = domain.MonitoringSurvivedMemorySize;
            this.message = message;
            this.start = MyMemory.Now();
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
                    AppDomain domain = AppDomain.CurrentDomain;
                    long allocated = domain.MonitoringTotalAllocatedMemorySize - memoryAllocated;
                    long survived = domain.MonitoringSurvivedMemorySize - memoryInUse;
                    MyMemory end = MyMemory.Now();

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine("{0} - ", message);
                    }

                    Console.WriteLine("Memory Difference = {0:N0} bytes", end.CurrentMemory - start.CurrentMemory);
                    Console.WriteLine("Total Allocated = {0:N0} bytes, Survived GCs = {1:N0} bytes", allocated, survived);
                    disposed = true;
                }
            }
        }
    }
 }
