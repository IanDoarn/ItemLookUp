using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Exception thrown when there is a issue with cannibalizations
    /// </summary>
    public class CannibalizationError : ItemLookUpException
    {
        public CannibalizationError() : base() { }
        public CannibalizationError(string message) : base(message) { }
        public CannibalizationError(string format, params object[] args) : base(string.Format(format, args)) { }
        public CannibalizationError(string message, Exception inner): base(message, inner) { }
    }
}
