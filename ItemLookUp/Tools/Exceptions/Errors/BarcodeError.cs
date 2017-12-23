using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Exception thrown when there is an issue with barcodes
    /// </summary>
    public class BarcodeError : ItemLookUpException
    {
        public BarcodeError() : base() { }
        public BarcodeError(string message) : base(message) { }
        public BarcodeError(string format, params object[] args) : base(string.Format(format, args)) { }
        public BarcodeError(string message, Exception inner) : base(message, inner) { }
    }
}
