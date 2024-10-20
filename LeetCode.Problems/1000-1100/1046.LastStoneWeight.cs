using static System.Formats.Asn1.AsnWriter;
public interface ILastStoneWeightGame
{
    public int LastStoneWeight(int[] stones);

}

public class LastStoneWeightGame : ILastStoneWeightGame
{
    public int LastStoneWeight(int[] stones)
    {
        var priorityQueue = new PriorityQueue<int, int>(stones.Length, Comparer<int>.Create((a, b) => b - a));
        priorityQueue.EnqueueRange(stones.Select(x => (x, x)));


        while (priorityQueue.Count > 1)
        {
            var y = priorityQueue.Dequeue();
            var x = priorityQueue.Dequeue();

            if (x == y)
                continue;

            var newStoneWeight = y - x;
            priorityQueue.Enqueue(newStoneWeight,newStoneWeight);
        }


        return priorityQueue.Count == 1 ? priorityQueue.Dequeue() : 0;
    }
}
