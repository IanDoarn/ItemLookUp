namespace ItemLookUp.Tools
{
    /// <summary>
    /// Transfer class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="T"></typeparam>
    public class Transfer<K, V, T>
    {
        private K from;
        private V to;
        private T item;
        
        /// <summary>
        /// Location to transfer from
        /// </summary>
        public K From { get { return from; } }

        /// <summary>
        /// Location to transfer to
        /// </summary>
        public V To { get { return to; } }

        /// <summary>
        /// Item being transfered
        /// </summary>
        public T Item { get { return item; } }

        /// <summary>
        /// Create a transfer for some item T from some K to some V
        /// </summary>
        /// <param name="from">Transfer from lacation</param>
        /// <param name="to">Transfer to location</param>
        /// <param name="item">Item to transfer</param>
        public Transfer(K from, V to, T item)
        {
            this.from = from;
            this.to = to;
            this.item = item;
        }

        public override string ToString()
        {
            return string.Format("From {0} -> To {1} :: Item {2}",
                from.ToString(), to.ToString(), item.ToString());
        }
    }
}
