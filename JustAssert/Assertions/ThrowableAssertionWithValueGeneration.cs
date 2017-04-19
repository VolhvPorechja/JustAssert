using System;
using System.Collections.Generic;
using JustAssert.Contracts;
using JustAssert.Safe;

namespace JustAssert.Assertions
{
    /// <summary>
    /// Assertion that checked for exceptionless execution, represented as <see cref="Func{TResult}"/> that generates value of TGen
    /// </summary>
    /// <typeparam name="TGen">Type of generating value.</typeparam>
    public class ThrowableAssertionWithValueGeneration<TGen> : AssertionContract
    {
        private readonly Func<TGen> mGenerator;
        private readonly Action<TGen> mSuccessCallback;
        private readonly Func<Exception, string> mMessageGenerator;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="generator"></param>
        /// <param name="messageGenerator"></param>
        /// <param name="successCallback"></param>
        /// <param name="isTerminal"></param>
        public ThrowableAssertionWithValueGeneration(Func<TGen> generator, Func<Exception, string> messageGenerator,
            bool isTerminal = false, Action<TGen> successCallback = null)
        {
            mMessageGenerator = messageGenerator;
            mSuccessCallback = successCallback;
            mGenerator = generator;
            IsTreminal = isTerminal;
        }

        public IEnumerable<string> GetFailsMessages()
        {
            var result = mGenerator.ExecuteGeneratorSafely();

            if (result.Failed)
            {
                if (mMessageGenerator != null)
                {
                    var generatedMessage =
                        ((Func<string>) (() => mMessageGenerator(result.Exception))).ExecuteGeneratorSafely();
                    return generatedMessage.Failed
                        ? new[]
                        {
                            $"Error occured during message generation: {generatedMessage.Exception}. Main exception: {result.Exception}"
                        }
                        : new[]
                        {
                            generatedMessage.Value
                        };
                }
            }

            if (mSuccessCallback != null)
            {
                var successProcessorCallResult = ((Action) (() => mSuccessCallback(result.Value))).ExecuteActionSafely();
                if (successProcessorCallResult.IsFailed)
                    return new[]
                    {
                        $"Exception occured during processing successfull result: {successProcessorCallResult.Exception}"
                    };
            }

            return new string[] {};
        }

        public bool IsTreminal { get; }
    }
}