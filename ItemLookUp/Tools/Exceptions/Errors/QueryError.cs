using ItemLookUp.Tools.Exceptions.Errors;
using System;


namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// QueryError
    /// Called when an issue occures executing or returning information from a query
    /// </summary>
    public class QueryError : ItemLookUpException
    {
        public QueryError() : base() { }
        public QueryError(string message) : base(message) { }
        public QueryError(string format, params object[] args) : base(string.Format(format, args)) { }
        public QueryError(string message, Exception inner): base(message, inner) { }
    }
}
