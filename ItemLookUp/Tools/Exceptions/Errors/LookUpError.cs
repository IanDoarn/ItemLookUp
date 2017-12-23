using ItemLookUp.Tools.Exceptions.Errors;
using System;


namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Exception called when the is an issue in the Search Class
    /// </summary>
    public class LookUpError : ItemLookUpException
    {
        public LookUpError() : base() { }
        public LookUpError(string message) : base(message) { }
        public LookUpError(string format, params object[] args) : base(string.Format(format, args)) { }
        public LookUpError(string message, Exception inner): base(message, inner) { }

    }
}
