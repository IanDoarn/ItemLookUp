namespace ItemLookUp.Barcodes
{
    class BZTag : Barcode
    {
        private string barcode;

        public string Barcode { get { return barcode; } set { barcode = value; } }

        public BZTag() { }

        public BZTag(string barcode)
        {
            this.barcode = barcode;
        }

        public override BarcodeEnum BType()
        {
            return BarcodeEnum.ZTAG;
        }

        public override string ToString()
        {
            return string.Format("Type: [ZTag] Tag Number: {0}", barcode);
        }

    }
}
