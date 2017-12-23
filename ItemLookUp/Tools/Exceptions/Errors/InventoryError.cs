using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// InventoryError Exception, throw when there is an issue with inventory
    /// </summary>
    public class InventoryError : ItemLookUpException
    {
        public InventoryError() : base() { }
        public InventoryError(string message) : base(message) { }
        public InventoryError(string format, params object[] args) : base(string.Format(format, args)) { }
        public InventoryError(string message, Exception inner) : base(message, inner) { }
    }
}
