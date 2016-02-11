using System;
using System.Runtime.CompilerServices;

namespace Scratch
{
    internal static class GCNotifyExtensions
    {
        private static readonly ConditionalWeakTable<object, GCCallback> store = new ConditionalWeakTable<object, GCCallback>();

        private sealed class GCCallback
        {
            private readonly object obj;
            private readonly Action<object> callback;

            internal GCCallback(object obj, Action<object> callback)
            {
                this.obj = obj;
                this.callback = callback;
            }

            ~GCCallback()
            {
                callback(obj);
            }
        }

        /// <summary>
        /// Registers an action to be called when the specified object is garbage collected.
        /// </summary>
        public static T GCNotify<T>(this T obj, Action<object> callback) where T : class
        {
            store.Add(obj, new GCCallback(obj, callback));
            return obj;
        }
    }
}
