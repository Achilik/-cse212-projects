public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Start assuming first item is highest
        int highPriorityIndex = 0;

        // Search entire queue
        for (int index = 1; index < _queue.Count; index++)
        {
            // Strictly greater preserves FIFO order
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Save value
        string value = _queue[highPriorityIndex].Value;

        // Remove item from queue
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}