using System;

namespace _Code.Extensions
{
    public static class ChainedCodeExtensions
    {
        public static T Do<T>(this T self, Action<T> action)
        {
            action?.Invoke(self);
            return self;
        }

        public static T Do<T>(this T self, Action<T> action, Func<bool> when)
        {
            if (when())
                action?.Invoke(self);

            return self;
        }

        public static T Do<T>(this T self, Action<T> action, bool when)
        {
            if (when)
                action?.Invoke(self);

            return self;
        }
    }
}