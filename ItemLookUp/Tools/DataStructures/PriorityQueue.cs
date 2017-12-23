using System;
using ItemLookUp.Tools.DataStructures;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Priority Queue implemetation of a Min Heap
/// 
/// </summary>
/// <remarks>The underlying data structure is a LinkedList</remarks>
namespace ItemLookUp.Tools
{
    /// <summary>
    /// Priority Queue implemented using a Min Heap
    /// 
    /// </summary>
    /// <remarks>The underlying data structure is a LinkedList</remarks>
    public class PriorityQueue<T> : IQueue<T> where T : IComparable
    {    

        /// <summary>
        /// LinkedList is used to represent to BST of the Heap
        /// Special formulas are used to acces the BSTs Nodes and
        /// each Nodes children and parent
        /// </summary>
        private LinkedList<T> data = new LinkedList<T>();

        private int size = 0;

        /// <summary>
        /// Returns current size of the queue
        /// </summary>
        public int Size { get { return size; } set { size = value; } }

        /// <summary>
        /// Returns whether the Queue is empty
        /// </summary>
        /// <returns>bool</returns>
        public bool isEmpty()
        {
            return data.Count == 0;
        }

        /// <summary>
        /// Returns the first item in the Queue
        /// </summary>
        /// <returns>T</returns>
        public T peek()
        {
            if(!isEmpty())
            {
                return data.ElementAt(0);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Returns if PriorityQueue contains item
        /// </summary>
        /// <param name="t">item</param>
        /// <returns>bool</returns>
        public bool Contains(T t)
        {
            return data.Contains(t);
        }

        /// <summary>
        /// Requeue items back into priority queue
        /// </summary>
        /// <param name="s">Stack of items to requeue</param>
        public void Requeue(Stack<T> s)
        {
            // Clear the LinkedList of data
            data.Clear();

            // Re add items from given stack
            while(!(s.Count == 0))
            {
                enqueue(s.Pop());
            }
        }

        /// <summary>
        /// Adds an item to the Queue and rebalances the tree so that
        /// the first node is always the smallest
        /// </summary>
        /// <param name="item">T item to add the the queue</param>
        public void enqueue(T item)
        {

            data.AddLast(item);
            size++;

            int cIndex = data.Count - 1;
            int pIndex = (cIndex - 1) / 2;

            while(data.ElementAt(cIndex).CompareTo(data.ElementAt(pIndex)) < 0)
            {
                T temp = data.ElementAt(cIndex);
                data.Find(temp).Value = data.ElementAt(pIndex);
                data.Find(data.ElementAt(pIndex)).Value = temp;

                cIndex = pIndex;
                pIndex = (cIndex - 1) / 2;
            }
        }


        /// <summary>
        /// Removes the first item in the Queue
        /// </summary>
        /// <returns>T</returns>
        public T dequeue()
        {
            if(data.Count == 0)
            {
                size = 0;
                return default(T);
            }
            else if (data.Count == 1)
            {
                T temp = data.ElementAt(0);
                data.Remove(temp);
                size = 0;
                return temp;
            }
            else
            {
                T toReturn = data.ElementAt(0);

                T last = data.ElementAt(data.Count - 1);
                data.Remove(last);

                data.Find(data.ElementAt(0)).Value = last;

                int pIndex = 0;
                while(true)
                {
                    int lIndex = 2 * pIndex + 1, lesserChildIndex = lIndex;
                    if(lIndex >= data.Count)
                    {
                        break;
                    }

                    int rIndex = lIndex + 1;
                    if(rIndex < data.Count && data.ElementAt(rIndex).CompareTo(data.ElementAt(lIndex)) < 0)
                    {
                        lesserChildIndex = rIndex;
                    }

                    if(data.ElementAt(lesserChildIndex).CompareTo(data.ElementAt(pIndex)) < 0)
                    {
                        T temp = data.ElementAt(lesserChildIndex);
                        data.Find(temp).Value = data.ElementAt(pIndex);
                        data.Find(data.ElementAt(pIndex)).Value = temp;

                        pIndex = lesserChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                size--;

                return toReturn;
            }
        }

        public override string ToString()
        {
            return data.ToString();
        }

    }
}
