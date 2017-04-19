using System;

namespace JustAssert.Safe
{
    /// <summary>
    /// Class for extending <see cref="Func{TResult}"/> functionality.
    /// </summary>
    public static class SafeExtensions
    {
        /// <summary>
        /// Execute given generator safely.
        /// </summary>
        /// <param name="unsafeGenerator"></param>
        /// <returns></returns>
        public static SafeGenerator<TType> ExecuteGeneratorSafely<TType>(this Func<TType> unsafeGenerator)
        {
            var safeExpression = new SafeGenerator<TType>(unsafeGenerator);
            safeExpression.Execute();
            return safeExpression;
        }

        /// <summary>
        /// Execute given action safely.
        /// </summary>
        /// <param name="unsafeAction"></param>
        /// <returns></returns>
        public static SafeAction ExecuteActionSafely(this Action unsafeAction)
        {
            var safeAction = new SafeAction(unsafeAction);
            safeAction.Execute();
            return safeAction;
        }
    }
}