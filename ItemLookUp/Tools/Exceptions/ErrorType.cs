namespace ItemLookUp.Tools.Exceptions
{
    /// <summary>
    /// Enumerates error types
    /// </summary>
    public enum ErrorType
    {
        // Default error
        DEFAULT,

        // Issue with cannibalization
        CANNIBALIZATION,

        // No connection to database
        NO_CONNECTION,

        // Problem with searching for information
        LOOK_UP,

        // Default query issue
        QUERY,

        // Query returned empty
        NO_DATA_RETURNED_FROM_QUERY,

        // Could not find the associated item in the inventory snapshot
        ITEM_NOT_IN_INVENTORY_SNAPSHOT,

        // Default error with inventory item
        INVENTORY,

        // Barcode could not be found or is unknown
        UKNOWN_BARCODE,

        // General error with the database
        DATABASE_ERROR

    }
}
