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
        public ConsoleKey Key{get {return key;}}
        private readonly ConsoleKey key;

        /// <summary>
        /// An action to perform when this options is selected.
        /// </summary>
        public Func<T> Action{get {return action;}}
        private readonly Func<T> action;

        /// <summary>
        /// A description of this option.
        /// </summary>
        public string Description{get {return description;}}
        private readonly string description;

        /// <summary>
        /// Creates a new option.
        /// </summary>
        public Option(ConsoleKey key, Func<T> action, string description)
        {
            this.key = key;
            this.action = action;
            this.description = description;
        }
    }
}
