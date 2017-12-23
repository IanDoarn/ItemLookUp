namespace ItemLookUp.LookUp.Inventory
{
    /// <summary>
    /// Container of an object
    /// </summary>
    /// <typeparam name="T">object to hold</typeparam>
    public class Container<T>
    {
        private string zone;
        private string position;
        private string shelf;

        private T item;

        /// <summary>
        /// Containers zone
        /// </summary>
        public string Zone { get { return zone; } }

        /// <summary>
        /// Containers position in the specified zone
        /// </summary>
        public string Position { get { return position; } }

        /// <summary>
        /// Containers shelf in the specific position
        /// </summary>
        public string Shelf { get { return shelf; } }

        /// <summary>
        /// Contents of the container
        /// </summary>
        public T Item { get { return item; } }

        /// <summary>
        /// Create a container that holds a specified product
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="shelf"></param>
        /// <param name="position"></param>
        public Container(string zone, string shelf, string position, T item)
        {
            this.zone = zone;
            this.shelf = shelf;
            this.position = position;
            this.item = item;
        }

        public override string ToString()
        {
            return zone + "-" + position + "-" + shelf;
        }
    }
}
