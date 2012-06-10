using System;
using System.Runtime.CompilerServices;

namespace Scratch
{
    internal static class GCNotifyExtensions
    {
        private static readonly ConditionalWeakTable<Object, GCCallback> store = new ConditionalWeakTable<Object, GCCallback>();

        private sealed class GCCallback
        {
            private readonly Object obj;
            private readonly Action<Object> callback;

            internal GCCallback(Object obj, Action<Object> callback)
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
        public static T GCNotify<T>(this T obj, Action<Object> callback) where T : class
        {
            store.Add(obj, new GCCallback(obj, callback));
            return obj;
        }
    }
}
