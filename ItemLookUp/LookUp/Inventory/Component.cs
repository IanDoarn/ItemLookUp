namespace ItemLookUp.LookUp.Inventory
{
    public class Component : Product
    {
        private string description;
        private string kitnumber;
        private int qtystandard;
        private int qty;

        /// <summary>
        /// Components product number
        /// </summary>
        public override string ProductNumber {  get { return productnumber; } }

        /// <summary>
        /// Description of the component
        /// </summary>
        public string Description { get { return description; } }

        /// <summary>
        /// Kit number the component lives in
        /// </summary>
        public string KitNumber { get { return kitnumber; } }

        /// <summary>
        /// Standard qty that parent kit requires of this component
        /// </summary>
        public int QtyStandard { get { return qtystandard; } }

        /// <summary>
        /// Actual number (qty) of this component in the kit
        /// </summary>
        public int Qty { get { return qty; } set { qty = value; } }
        
        public Component(string productnumber, string description, string kitnumber, int qtystandard, int qty) 
            : base(productnumber)
        {
            this.description = description;
            this.kitnumber = kitnumber;
            this.qtystandard = qtystandard;
            this.qty = qty;
        }

        /// <summary>
        /// Returns whether the current component 
        /// meets the required qty standard
        /// </summary>
        /// <returns>bool</returns>
        public bool isFull()
        {
            return this.qty == this.qtystandard;
        }

        public override string ToString()
        {
            return productnumber;
        }
    }
}
