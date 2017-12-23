/// <summary>
/// Queue interface to define methods for the PriorityQueue
/// </summary>
namespace ItemLookUp.Tools.DataStructures
{
    interface IQueue<T>
    {
        /// <summary>
        /// Returns whether the Queue is empty
        /// </summary>
        /// <returns>bool</returns>
        bool isEmpty();

        /// <summary>
        /// Returns the first item in the Queue
        /// </summary>
        /// <returns>T</returns>
        T peek();

        /// <summary>
        /// Adds an item to the Queue
        /// </summary>
        /// <param name="item">T item to add the the queue</param>
        void enqueue(T item);

        /// <summary>
        /// Removes the first item in the Queue
        /// </summary>
        /// <returns>T</returns>
        T dequeue();
    }
}
