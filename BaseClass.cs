using System;
using System.Collections;
using System.Diagnostics;

namespace Scratch
{
    public abstract class BaseClass
    {
        /// <summary>
        /// Writes a blank line to the console.
        /// </summary>
        protected static void WL()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes to the console.
        /// </summary>
        protected static void WL(object text, params object[] args)
        {
            string textStr = text?.ToString() ?? "<null>";

            if (args == null || args.Length == 0)
            {
                Console.WriteLine(textStr);
            }
            else
            {
                Console.WriteLine(textStr, args);
            }
        }

        /// <summary>
        /// Writes an exception to the console.
        /// </summary>
        /// <remarks>
        /// The full exception information will be output, including:
        /// <list type="bullet">
        /// <item><description>the type of the exception</description></item>
        /// <item><description>the exception message</description></item>
        /// <item><description>the exception stack trace</description></item>
        /// <item><description>any <see cref="Exception.Data"/> information</description></item>
        /// </list>
        /// Inner exceptions will also have the above information output in full.
        /// </remarks>
        internal static void WE(Exception e)
        {
            WL();
            WL(new string('-', 70));
            WL(e.GetType());
            WL(new string('-', 20));
            WL(e.Message);
            WL(new string('-', 20));
            WL(e.StackTrace);

            if (e.Data.Count > 0)
            {
                WL(new string('-', 20));

                foreach (DictionaryEntry entry in e.Data)
                {
                    WL("   {0}: {1}", entry.Key, entry.Value);
                }
            }

            WL(new string('-', 70));

            Exception baseException = e.GetBaseException();

            if (baseException != e)
            {
                WE(baseException);
            }

            WL();
        }

        /// <summary>
        /// Reads a line of text from the console.
        /// </summary>
        protected static string RL()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Signals a breakpoint to an attached debugger.
        /// </summary>
        protected static void Break()
        {
            Debugger.Break();
        }
    }
}
