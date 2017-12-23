using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// ConnectionError Exception, thorwn when there is an issue connection to a database
    /// </summary>
    public class ConnectionError : ItemLookUpException
    {
        public ConnectionError() : base() { }
        public ConnectionError(string message) : base(message) { }
        public ConnectionError(string format, params object[] args) : base(string.Format(format, args)) { }
        public ConnectionError(string message, Exception inner): base(message, inner) { }
    }
}
