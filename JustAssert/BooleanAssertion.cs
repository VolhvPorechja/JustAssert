using System;
using System.Collections.Generic;

namespace JustAssert
{
    /// <summary>
    /// Class that represent simple boolean assertion.
    /// </summary>
    public class BooleanAssertion : AssertionContract
    {
        private readonly Func<bool> mAssertion;
        private readonly string mMessage;
        private readonly Action mSuccessCallback;
        private readonly Action<Exception> mExceptionProcessor;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="assertion">Checking assertion.</param>
        /// <param name="message">Message for fail case.</param>
        /// <param name="isTerminal">Is assertion will terminate processing assertions on it's level.</param>
        /// <param name="successCallback">Callback for success case.</param>
        /// <param name="exceptionProcessor">Callback for case when assertion executed with exception.</param>
        public BooleanAssertion(Func<bool> assertion, string message, bool isTerminal = false,
            Action successCallback = null, Action<Exception> exceptionProcessor = null)
        {
            mExceptionProcessor = exceptionProcessor;
            mSuccessCallback = successCallback;
            IsTreminal = isTerminal;
            mMessage = message;
            mAssertion = assertion;
        }

        public IEnumerable<string> GetFailsMessages()
        {
            var value = mAssertion.ExecuteSafely();
            if (value.Failed)
                mExceptionProcessor?.Invoke(value.Exception);

            if (value.Failed || value.Value)
                return new[] {mMessage};

            mSuccessCallback?.Invoke();
            return new string[] {};
        }

        public bool IsTreminal { get; }
    }
}