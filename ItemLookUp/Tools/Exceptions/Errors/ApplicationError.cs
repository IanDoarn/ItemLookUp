using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Exception thrown when there is a general issue with the application
    /// </summary>
    public class ApplicationError : ItemLookUpException
    {
        public ApplicationError() : base() { }
        public ApplicationError(string message) : base(message) { }
        public ApplicationError(string format, params object[] args) : base(string.Format(format, args)) { }
        public ApplicationError(string message, Exception inner) : base(message, inner) { }
    }
}
