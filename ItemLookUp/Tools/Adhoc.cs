namespace ItemLookUp.Tools
{   
    /// <summary>
    /// Adhoc transfer
    /// Transfer that must be created by the user to move inventory from 
    /// one place to another view the website or a scanner gun
    /// </summary>
    public class Adhoc<T, K>
    {
        /// <summary>
        /// Container to transfer from
        /// </summary>
        private T fromContainer;
        /// <summary>
        /// Container to transfer to
        /// </summary>
        private T toContainer;

        /// <summary>
        /// Get or Set the container to transfer to
        /// </summary>
        public T ToContainer { get { return toContainer; } set { toContainer = value; } }
        /// <summary>
        /// Get or Set the container to transfer from
        /// </summary>
        public T FromContainer { get { return fromContainer; } set { fromContainer = value; } }

        /// <summary>
        /// Item being transfered
        /// </summary>
        private K item;
        /// <summary>
        /// Gets the item being transfered
        /// </summary>
        public K Item { get { return item; } }

        /// <summary>
        /// Qty to transfer
        /// </summary>
        private int qty;
        /// <summary>
        /// Qty to transfers
        /// </summary>
        public int Qty { get { return qty; } }


        /// <summary>
        /// Create Adhoc transfer
        /// </summary>
        /// <param name="from">Container to pull from</param>
        /// <param name="to">Container to transfer to</param>
        /// <param name="item">Item to transfer</param>
        /// <param name="qty">Amount to transfer</param>
        public Adhoc(T from, T to, K item, int qty)
        {
            fromContainer = from;
            toContainer = to;
            this.item = item;
            this.qty = qty;
        }

        /// <summary>
        /// Gets a string representation of the transfer
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string s = string.Format("From {0} To {1} Item {2} QTY: {3}", 
                fromContainer.ToString(), toContainer.ToString(), item.ToString(), qty.ToString());
            return s;
        }
    }
}
