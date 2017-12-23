namespace ItemLookUp.Config
{
    /// <summary>
    /// Global constants used thougout the program
    /// </summary>
    public static class Constants
    {
        private const double breakdown_threshold = 0.15D;

        private const string delimiter = ";";

        private const string kitBarcodeRegexVerify = @"^[zZ]-\d*-\d{1,3}$";
        private const string ztagBarcodeRegexVerify = @"(?i)^zi\d*$";

        /*
         * Getters here are static so that the Constants class 
         * does not have to be instanciated to access these values
         */

        /// <summary>
        /// Threshold for percentage valid a kit can 
        /// reach before it is considered for breakdown
        /// </summary>
        public static double BREAKDOWN_THRESHOLD { get { return breakdown_threshold; } }

        /// <summary>
        /// Delimiter to concatenate strings with
        /// </summary>
        public static string DELIMITER { get { return delimiter; } }

        /// <summary>
        /// Regex match pattern for kit barcodes
        /// </summary>
        public static string KitBarcodeRegexVerify { get { return kitBarcodeRegexVerify; } }

        /// <summary>
        /// Regex match pattern for ZTag barcodes
        /// </summary>
        public static string ZtagBarcodeRegexVerify {  get { return ztagBarcodeRegexVerify; } }
    }
}
