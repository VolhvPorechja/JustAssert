﻿using System;

namespace JustAssert
{
    /// <summary>
    /// Class that wraps <see cref="Func{TResult}"/> call in safe manner.
    /// </summary>
    /// <typeparam name="TType">Type of generated by function value.</typeparam>
    public class SafeExpression<TType>
    {
        private readonly Func<TType> mUnsafeTypeGenerator;
        private bool mExecuted;

        /// <summary>
        /// Result of function generation
        /// </summary>
        public TType Value { get; private set; }

        /// <summary>
        /// Is exception occured during value generation.
        /// </summary>
        public bool Failed { get; private set; }

        /// <summary>
        /// Exception thrown during value generation.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="unsafeTypeGenerator"></param>
        public SafeExpression(Func<TType> unsafeTypeGenerator)
        {
            mUnsafeTypeGenerator = unsafeTypeGenerator;
        }

        /// <summary>
        /// Execute generator.
        /// </summary>
        public void Execute()
        {
            if (mExecuted)
                return;

            try
            {
                Value = mUnsafeTypeGenerator();
            }
            catch (Exception ex)
            {
                Failed = true;
                Exception = ex;
            }

            mExecuted = true;
        }
    }
}