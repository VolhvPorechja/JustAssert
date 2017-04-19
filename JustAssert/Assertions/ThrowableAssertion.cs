using System;
using System.Collections.Generic;
using JustAssert.Contracts;

namespace JustAssert.Assertions
{
    /// <summary>
    /// Assertion that checked for exceptionless execution, represented as simple <see cref="Action"/>
    /// </summary>
    public class ThrowableAssertion : AssertionContract
    {
        private readonly Action mThrowableAction;
        private readonly Func<Exception, string> mErrorMessageGenerator;
        private readonly Action mSuccessProcessor;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="throwableAction"></param>
        /// <param name="errorMessageGenerator"></param>
        /// <param name="isTerminal"></param>
        /// <param name="successProcessor"></param>
        public ThrowableAssertion(Action throwableAction, Func<Exception, string> errorMessageGenerator,
            bool isTerminal = false, Action successProcessor = null)
        {
            mSuccessProcessor = successProcessor;
            mErrorMessageGenerator = errorMessageGenerator;
            mThrowableAction = throwableAction;
            IsTreminal = isTerminal;
        }

        public IEnumerable<string> GetFailsMessages()
        {
            
        }

        public bool IsTreminal { get; }
    }
}