public interface IKthLargestElementInAnArray
{
    public int FindKthLargest(int[] nums, int k);
}

public class KthLargestElementInAnArray : IKthLargestElementInAnArray
{
    public int FindKthLargest(int[] nums, int k)
    {
        var priorityQueue = new PriorityQueue<int, int>(nums.Length, Comparer<int>.Create((a, b) => b - a));
        priorityQueue.EnqueueRange(nums.Select(x => (x, x)));


        var count = 0;
        while (count < k - 1)
        {
            priorityQueue.Dequeue();
            count++;
        }

        return priorityQueue.Dequeue();
    }
}
