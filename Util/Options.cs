using System;
using System.Collections.Generic;
using System.Linq;

namespace Scratch
{
    internal static class Options
    {
        /// <summary>
        /// Gets an option from the specified set of options.
        /// </summary>
        /// <param name="optionText">A message to be displayed with the possible options.</param>
        /// <param name="options">A list of possible options.</param>
        internal static T GetOption<T>(string optionText, params Option<T>[] options)
        {
            Dictionary<ConsoleKey, Func<T>> funcMap = options.ToDictionary(opt => opt.Key, opt => opt.Action);
            Console.WriteLine();

            foreach (Option<T> option in options)
            {
                Console.WriteLine("{0}: {1}", option.Key, option.Description);
            }

            Console.WriteLine();
            Console.Write(optionText + " :> ");

            ConsoleKeyInfo readKey;

            do
            {
                readKey = Console.ReadKey(false);
            }
            while (!funcMap.ContainsKey(readKey.Key));

            Console.WriteLine();
            Console.WriteLine();
            Func<T> func = funcMap[readKey.Key];
            T ret = func();
            return ret;
        }
    }
}
