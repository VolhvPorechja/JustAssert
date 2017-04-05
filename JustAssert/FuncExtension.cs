using System;

namespace JustAssert
{
    /// <summary>
    /// Class for extending <see cref="Func{TResult}"/> functionality.
    /// </summary>
    public static class FuncExtension
    {
        /// <summary>
        /// Execute given generator safely.
        /// </summary>
        /// <param name="unsafeGenerator"></param>
        /// <returns></returns>
        public static SafeExpression<TType> ExecuteSafely<TType>(this Func<TType> unsafeGenerator)
        {
            var safeExpression = new SafeExpression<TType>(unsafeGenerator);
            safeExpression.Execute();
            return safeExpression;
        }
    }
}