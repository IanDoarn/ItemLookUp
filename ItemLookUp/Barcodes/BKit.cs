namespace ItemLookUp.Barcodes
{
    public class BKit : Barcode
    {
        private string barcodenumber, productid, productnumber, description, serialnumber;

        public string BarcodeNumber { get { return barcodenumber; } set { barcodenumber = value; } }
        public string ProductId { get { return productid; } set { productid = value; } }
        public string ProductNumber { get { return productnumber; } set { productnumber = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string SerialNumber { get { return serialnumber; } set { serialnumber = value; } }
        
        public BKit() { }

        public BKit(string barcodenumber, string productid, string productnumber, string description, string serialnumber)
        {
            this.barcodenumber = barcodenumber;
            this.productid = productid;
            this.productnumber = productnumber;
            this.description = description;
            this.serialnumber = serialnumber;
        }

        public override BarcodeEnum BType()
        {
            return BarcodeEnum.KIT;
        }

        public override string ToString()
        {
            return string.Format("Type: [Kit] ID: {0} Product Number: {1} Serial Number: {2} Description: {3}",
                productid, productnumber, serialnumber, description);
        }
    }
}
