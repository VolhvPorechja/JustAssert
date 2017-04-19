using System.Collections.Generic;

namespace JustAssert.Contracts
{
    /// <summary>
    /// Interface for assertion class.
    /// </summary>
    public interface AssertionContract
    {
        /// <summary>
        /// Get messages for failed assertions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetFailsMessages();

        /// <summary>
        /// Is given assertion terminal in it's level.
        /// </summary>
        bool IsTreminal { get; }
    }
}