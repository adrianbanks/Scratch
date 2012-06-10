using System;

namespace Scratch
{
    /// <summary>
    /// Logs to the console whenever a garbage collection occurs.
    /// </summary>
    public sealed class GCLog
    {
        private static bool active;

        /// <summary>
        /// Registers an interest in logging to the console when a garbage collection occurs.
        /// </summary>
        public static void Register()
        {
            active = true;
            new GCLog();
        }

        /// <summary>
        /// Unregisters an interest in logging to the console when a garbage collection occurs.
        /// </summary>
        public static void Unregister()
        {
            active = false;
        }

        private GCLog()
        {}

        ~GCLog()
        {
            if (active)
            {
                Console.WriteLine("GC at {0}", DateTime.Now);
                Console.WriteLine("    GC0: {0}", GC.CollectionCount(0));
                Console.WriteLine("    GC1: {0}", GC.CollectionCount(1));
                Console.WriteLine("    GC2: {0}", GC.CollectionCount(2));
                
                if (!AppDomain.CurrentDomain.IsFinalizingForUnload() && !Environment.HasShutdownStarted)
                {
                    new GCLog();
                }
            }
        }
    }
}
