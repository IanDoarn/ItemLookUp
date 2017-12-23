namespace ItemLookUp.LookUp.Inventory
{
    /// <summary>
    /// Abstract class for products to inherit
    /// </summary>
    public abstract class Product
    {
        protected string productnumber;

        /// <summary>
        /// Product number of item
        /// </summary>
        public abstract string ProductNumber { get; }

        public Product(string productnumber)
        {
            this.productnumber = productnumber;
        }
    }
}
