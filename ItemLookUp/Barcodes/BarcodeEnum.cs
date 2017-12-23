using System;

namespace ItemLookUp.Barcodes
{
    /// <summary>
    /// Enumaration table for the different types of supported barcodes
    /// </summary>
    [Flags]
    public enum BarcodeEnum
    {
        UNKNOWN = -1,
        KIT = 0,      
        ZTAG = 1,
        BIN = 2,
        HIBC = 3,
        GS1 = 4
    }
}
