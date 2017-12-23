using ItemLookUp.LookUp.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemLookUp.Tools
{
    /// <summary>
    /// Cannibalizer
    /// This class takes information about objects that contain components and 
    /// builds a process to maximize the amount of valid kits that can be made
    /// with the supplied kits.
    /// 
    /// This class works with an PriorityQueue<T> that implements a Min Heap. Items in
    /// the queue are prioritized based on the amount of components missing from them.
    /// <remarks>
    /// This class works best with Kit objects
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// </T>
    /// </summary>
    public class Cannibalizer<T> where T : IComparable
    {
        private ProcessBuilder processbuilder;
        private PriorityQueue<T> queue;
        private LinkedList<Adhoc<Kit, Component>> adhocTransfers;

        private Stack<T> invalidkits = new Stack<T>();
        private Stack<T> validkits = new Stack<T>();

        private int queueditems = 0;

        /// <summary>
        /// PriorityQueue to keep track of kit objects. Priority based on kit missing
        /// the least number of components
        /// </summary>
        public PriorityQueue<T> KitQueue { get { return queue; } }

        /// <summary>
        /// Stack to store valid kits
        /// </summary>
        public Stack<T> ValidKits { get { return validkits; } }

        /// <summary>
        /// Stack to store invalid kits
        /// </summary>
        public Stack<T> InvalidKits { get { return invalidkits; } }

        /// <summary>
        /// Gets collection of adhoc transfers
        /// </summary>
        public LinkedList<Adhoc<Kit, Component>> AdhocTransfers { get { return adhocTransfers; } }

        /// <summary>
        /// Gets the process builder for the cannibalizer
        /// </summary>
        public ProcessBuilder Process { get { return processbuilder; } }

        /// <summary>
        /// Create a cannibalizer object
        /// </summary>
        public Cannibalizer()
        {
            queue = new PriorityQueue<T>();
        }
        /// <summary>
        /// Create a cannibalizer object
        /// </summary>
        /// <param name="items">LinkedList of items to load</param>
        public Cannibalizer(LinkedList<T> items)
        {
            load(items);
            queueditems = queue.Size;
        }

        /// <summary>
        /// Method to load items into queue from given LinkedList of objects to load
        /// </summary>
        /// <param name="itemsToLoad">LinkedList of items to add to the queue</param>
        /// <returns>PriorityQueue</returns>
        public void load(LinkedList<T> itemsToLoad)
        {
            queue = new PriorityQueue<T>();

            foreach(T item in itemsToLoad)
            {
                addProduct(item);
            }
        }

        /// <summary>
        /// Add a product to the queue, ite the product is a valid
        /// kit, ignore it.
        /// </summary>
        /// <param name="t">item to add</param>
        public void addProduct(T t)
        {
            Kit k = (Kit)(object) t;
            
            // Only add the kit if it is invalid
            if(!k.isValid())
            {
                queue.enqueue(t);
                queueditems = queue.Size;
            }        
            else
            {
                Console.WriteLine(string.Format(@"Kit {0} Serial [{1}] ommited, it is valid", k.ProductNumber, k.SerialNumber));
            }  
        }

        /// <summary>
        /// Removes the first item from the queue
        /// </summary>
        /// <returns>First item in the queue</returns>
        public T removeProduct()
        {
            T t = queue.dequeue();
            queueditems = queue.Size;
            return t;
        }
        
        /// <summary>
        /// Returns a string representation of the current cannibalization queue
        /// </summary>
        /// <returns>string</returns>
        public string ViewQueue()
        {
            StringBuilder sb = new StringBuilder();
            Stack<T> s = new Stack<T>();
            int i = 1;
            
            sb.Append("Current Queue: " + Environment.NewLine);

            while (!queue.isEmpty())
            {
                Kit k = (Kit)(object)queue.peek();
                s.Push(queue.dequeue());

                sb.Append(string.Format(@"{0}) Kit {1} Serial {2} Valid = [{3}]{4}",
                    i.ToString(), k.ProductNumber, k.SerialNumber, k.isValid().ToString(), Environment.NewLine));

                i++;
            }
            queue.Requeue(s);

            return sb.ToString();                
        }

        /// <summary>
        /// Public wrapper for the canniblize method
        /// </summary>
        public void Cannibalize()
        {
            cannibalize();
        }

        /// <summary>
        /// Create a cannibalization process to create valid kits from
        /// current collection of kits
        /// </summary>
        private void cannibalize()
        {
            // Create a new ProcessBuilder
            processbuilder = new ProcessBuilder();

            // Create a new linkedlist of adhoc transfers
            adhocTransfers = new LinkedList<Adhoc<Kit, Component>>();

            // Check if the queue is empty
            if (queue.isEmpty())
            {
                return;
            }                
            // If there is only one item in the queue, move it to 
            // the invalid kits stack and end
            else if(queue.Size == 1)
            {
                invalidkits.Push(queue.dequeue());
                return;
            }

            else
            {
                // Create stack to keep track of kits visited
                Stack<T> kitsseen = new Stack<T>();

                // Get the first kit from the queue, this is the kit we will be cannibalizing into
                Kit first = (Kit)(object)queue.dequeue();

                // Create a list of components currently missing from the first kit
                List<Component> missing = new List<Component>();
                foreach (Component c in first.Components)
                    if (!c.isFull())
                        missing.Add(c);

                // Set procbuilder primary to the first kit
                processbuilder.SetPrimary(first);

                // Begin going through the queue
                while (!queue.isEmpty())
                {
                    // Get the second kit from the queue, this is the kit we will be pulling items from
                    Kit second = (Kit)(object)queue.dequeue();

                    // set procbuilder secondary kit
                    processbuilder.SetSecondary(second);

                    // Iterate through each component in the missing list
                    foreach (Component c in first.Components)
                    {
                        // See if the component missing from the first kit is in the second kit
                        foreach (Component s in second.Components)
                        {
                            if (!c.isFull() && s.ProductNumber == c.ProductNumber && s.Qty >= 1)
                            {
                                // This is the missing component and there is enough to
                                // take atleast 1
                                int qtyTaken = 0;

                                while (s.Qty > 0)
                                {
                                    // Increment the component in the first kit by 1
                                    c.Qty++;
                                    s.Qty--;
                                    qtyTaken++;
                                    // Check if it is full
                                    if(c.isFull())
                                        break;
                                }

                                // Create an adhoc transfer for cannibalization
                                // Add the adhoc to the list
                                adhocTransfers.AddLast(new Adhoc<Kit, Component>(second, first, c, qtyTaken));

                                //Console.WriteLine(string.Format(@"Component {0} qty {1} removed from Kit [{2}] serial [{3}]",
                                //    c.ProductNumber, qtyTaken, second.ProductNumber, second.SerialNumber));
                            }
                        }
                    }
                    

                    // Check to see if the first kit is valid now
                    if (first.isValid())
                    {
                        // Push second kit to kits seen
                        kitsseen.Push((T)(object)second);

                        validkits.Push((T)(object)first);
                        //Console.WriteLine(string.Format("Kit {0} serial [{1}] is now valid.", first.ProductNumber, first.SerialNumber));
                        //Console.WriteLine();

                        // Dequeue the remaining kits since our first kit is now valid
                        while(!queue.isEmpty())
                            kitsseen.Push(queue.dequeue());

                        break;
                    }
                    else
                    {
                        // Push second kit to kits seen
                        kitsseen.Push((T)(object)second);
                    }
                   
                }
                // Check to see if the first kit is valid now after 
                // visiting every other kit in the queue
                if (!validkits.Contains((T)(object)first) && first.isValid())
                {
                    validkits.Push((T)(object)first);
                    Console.WriteLine(string.Format("Kit {0} serial [{1}] is now valid.", first.ProductNumber, first.SerialNumber));
                    Console.WriteLine();
                }
                else if (!first.isValid())
                {
                    // Kit is still not valid after visiting every other kit in the queue
                    // push it to the invalid kits stack
                    invalidkits.Push((T)(object)first);
                }

                // Requeue the kits seen
                queue.Requeue(kitsseen);

                // Create process
                processbuilder.Add(adhocTransfers);

            }
        }
    }
}
