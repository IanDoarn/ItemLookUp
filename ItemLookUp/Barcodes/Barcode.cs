namespace ItemLookUp.Barcodes
{
    /// <summary>
    /// Abstract class of barcode types
    /// </summary>
    public abstract class Barcode
    {
        /// <summary>
        /// BarcodeEnum of the type of barcode
        /// </summary>
        /// <returns></returns>
        abstract public BarcodeEnum BType();
    }
}
