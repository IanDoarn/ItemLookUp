using ItemLookUp.Tools.Exceptions.Errors;
using System;

namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Handles errors and throw the proper exception based on
    /// the error enum
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Throws an exception based on given enum type and args
        /// </summary>
        /// <param name="eType">Error Type</param>
        /// <param name="args">arguments to pass to the exception</param>
        public static ItemLookUpException Throw(ErrorType eType, string message)
        {
            return throwException(eType, message);
        }

        /// <summary>
        /// Method to create and throw the exception
        /// </summary>
        /// <param name="eType"></param>
        /// <param name="args"></param>
        private static ItemLookUpException throwException(ErrorType eType, string message)
        {
            switch(eType)
            {
                default:
                    return new ApplicationError(message);
                case ErrorType.DEFAULT:
                    return new ApplicationError(message);
                case ErrorType.CANNIBALIZATION:
                    return new CannibalizationError(message);
                case ErrorType.INVENTORY:
                    return new InventoryError(message);
                case ErrorType.ITEM_NOT_IN_INVENTORY_SNAPSHOT:
                    return new InventoryError("Item not in inventroy snapshot. " + message);
                case ErrorType.LOOK_UP:
                    return new LookUpError(message);
                case ErrorType.NO_CONNECTION:
                    return new ConnectionError(message);
                case ErrorType.NO_DATA_RETURNED_FROM_QUERY:
                    return new QueryError("No data returned from query. " + message);
                case ErrorType.QUERY:
                    return new QueryError(message);
                case ErrorType.UKNOWN_BARCODE:
                    return new BarcodeError(message);
                case ErrorType.DATABASE_ERROR:
                    return new DatabaseError(message);
            }
        }
    }
}
