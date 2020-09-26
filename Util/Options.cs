using System;
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
            var funcMap = options.ToDictionary(opt => opt.Key, opt => opt.Action);
            Console.WriteLine();

            foreach (var option in options)
            {
                Console.WriteLine($@"{option.Key}: {option.Description}");
            }

            Console.WriteLine();
            Console.Write($@"{optionText} :> ");

            ConsoleKeyInfo readKey;

            do
            {
                readKey = Console.ReadKey(false);
            }
            while (!funcMap.ContainsKey(readKey.Key));

            Console.WriteLine();
            Console.WriteLine();
            var func = funcMap[readKey.Key];
            var ret = func();
            return ret;
        }
    }
}
