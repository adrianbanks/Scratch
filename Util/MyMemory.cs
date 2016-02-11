using System;
using System.Diagnostics;
using System.Globalization;

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
        public long PeakMemory{get;private set;}

        /// <summary>
        /// The current memory.
        /// </summary>
        public long CurrentMemory{get;private set;}

        private MyMemory()
        {
            Process processInfo = Process.GetCurrentProcess();
            this.PeakMemory = (processInfo.PeakWorkingSet64);
            this.CurrentMemory = (processInfo.WorkingSet64);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Peak Memory = {0:N0} bytes, Current Memory = {1:N0} bytes", PeakMemory, CurrentMemory);
        }

        public static implicit operator string(MyMemory myMemory)
        {
            if (myMemory == null)
            {
                throw new ArgumentNullException("myMemory");
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
