using System;

namespace ItemLookUp.Tools.Exceptions.Errors
{
    /// <summary>
    /// Abstract class id for exceptions thrown by the application
    /// </summary>
    public abstract class ItemLookUpException : Exception
    {
        public ItemLookUpException() : base() { }
        public ItemLookUpException(string message) : base(message) { }
        public ItemLookUpException(string format, params object[] args) : base(string.Format(format, args)) { }
        public ItemLookUpException(string message, Exception inner): base(message, inner) { }
    }
}
