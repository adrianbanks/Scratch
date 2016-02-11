using System;

namespace Scratch
{
    /// <summary>
    /// A possible option for use with <see cref="Options.GetOption{T}"/>.
    /// </summary>
    internal sealed class Option<T>
    {
        /// <summary>
        /// The key that corresponds to this option.
        /// </summary>
        public ConsoleKey Key { get; }

        /// <summary>
        /// An action to perform when this options is selected.
        /// </summary>
        public Func<T> Action { get; }

        /// <summary>
        /// A description of this option.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Creates a new option.
        /// </summary>
        public Option(ConsoleKey key, Func<T> action, string description)
        {
            Key = key;
            Action = action;
            Description = description;
        }
    }
}
