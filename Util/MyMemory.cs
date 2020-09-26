using System;
using System.Diagnostics;

namespace Scratch
{
    /// <summary>
    /// A class that can output information about the
    /// memory usage of the current process.
    /// </summary>
    public sealed class MyMemory
    {
        /// <summary>
        /// The current peak memory.
        /// </summary>
        public long PeakMemory { get; }

        /// <summary>
        /// The current memory.
        /// </summary>
        public long CurrentMemory { get; }

        private MyMemory()
        {
            var processInfo = Process.GetCurrentProcess();
            PeakMemory = processInfo.PeakWorkingSet64;
            CurrentMemory = processInfo.WorkingSet64;
        }

        public override string ToString()
        {
            return $"Peak Memory = {PeakMemory:N0} bytes, Current Memory = {CurrentMemory:N0} bytes";
        }

        public static implicit operator string(MyMemory myMemory)
        {
            if (myMemory == null)
            {
                throw new ArgumentNullException(nameof(myMemory));
            }

            return myMemory.ToString();
        }

        /// <summary>
        /// Creates a snapshot instance with the current memory information.
        /// </summary>
        public static MyMemory Now()
        {
            return new MyMemory();
        }
    }
}
