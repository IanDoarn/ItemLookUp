using ItemLookUp.LookUp;
using ItemLookUp.LookUp.Inventory;
using ItemLookUp.Tools.Exceptions;
using System.Collections.Generic;


namespace ItemLookUp.Tools.Breakdown
{
    /// <summary>
    /// Create a breakdown process for a given kit and its components
    /// </summary>
    public class KitBreakdown
    {
        private Kit currentKit;
        private Search search;
        private SortedSet<string> locations;

        /// <summary>
        /// Create a new KitBreakdown process
        /// </summary>
        /// <param name="k">Kit to breakdown</param>
        public KitBreakdown(Kit k, Search search)
        {
            this.currentKit = k;
            this.search = search;
            locations = new SortedSet<string>();
        }

        /// <summary>
        /// Check to see if current kit is empty
        /// </summary>
        /// <returns></returns>
        private bool isEmpty()
        {
            return (currentKit.ComponentQty == 0 || currentKit.Components.Count == 0);
        }

        /// <summary>
        /// Create a process to breakdown kits
        /// </summary>
        /// <returns></returns>
        public LinkedList<Transfer<Kit, Container<Component>, Component>> Breakdown()
        {
            // Check if the kit is empty
            if(isEmpty())
            {
                throw ErrorHandler.Throw(ErrorType.INVENTORY, "Kit is empty.");
            }
            else
            {
                // If not create a procedure for breakdown
                return breakdown();
            }
        }

        /// <summary>
        /// Create a list of transfers to breakdown kits
        /// </summary>
        /// <returns></returns>
        private LinkedList<Transfer<Kit, Container<Component>, Component>> breakdown()
        {
            // Created a linkedlist to store transfers
            LinkedList<Transfer<Kit, Container<Component>, Component>> transfers = new LinkedList<Transfer<Kit, Container<Component>, Component>>();
            
            // Create transfers for each component
            foreach(Component c in currentKit.Components)
            {
                // Only create transfers for components with a qty > 0
                if(c.Qty > 0)
                {
                    // Get the components mapped location
                    string[] bin = search.ItemMapping(c.ProductNumber).Split('-');

                    // Create a new container for the components
                    Container<Component> container = new Container<Component>(bin[0], bin[1], bin[2], c);

                    if (!locations.Contains(container.ToString()))
                        locations.Add(container.ToString());

                    // Create a transfer for the component
                    Transfer<Kit, Container<Component>, Component> transfer = new Transfer<Kit, Container<Component>, Component>(currentKit, container, c);

                    // Add the transfer for the list
                    transfers.AddLast(transfer);
                }
            }

            return transfers;
        }
        
        /// <summary>
        /// Return a list of bin locations
        /// </summary>
        /// <returns></returns>
        public SortedSet<string> PutAwayLocations()
        {
            return locations;
        }
    }
}
