using System;

namespace JustAssert.Safe
{
    /// <summary>
    /// Class that wraps execution of <see cref="Action"/> in safe environment.
    /// </summary>
    public class SafeAction
    {
        private readonly Action mUnsafeExpression;
        private bool mIsExecuted;

        /// <summary>
        /// Is exception occurred during execution.
        /// </summary>
        public bool IsFailed { get; private set; }

        /// <summary>
        /// Exception occurred during exection.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="unsafeExpression"></param>
        public SafeAction(Action unsafeExpression)
        {
            if (unsafeExpression == null) throw new ArgumentNullException(nameof(unsafeExpression));
            mUnsafeExpression = unsafeExpression;
        }

        /// <summary>
        /// Execute expression.
        /// </summary>
        public void Execute()
        {
            if(mIsExecuted)
                return;

            try
            {
                mUnsafeExpression();
            }
            catch (Exception ex)
            {
                IsFailed = true;
                Exception = ex;
            }

            mIsExecuted = true;
        }
    }
}