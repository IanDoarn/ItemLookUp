using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Exception thrown when there is a general issue with the application
    /// </summary>
    public class DatabaseError : ItemLookUpException
    {
        public DatabaseError() : base() { }
        public DatabaseError(string message) : base(message) { }
        public DatabaseError(string format, params object[] args) : base(string.Format(format, args)) { }
        public DatabaseError(string message, Exception inner) : base(message, inner) { }
    }
}
