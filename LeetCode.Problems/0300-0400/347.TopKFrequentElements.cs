public interface ITopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k);
}


public class TopKFrequentElementsNSolution : ITopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {

        //Get The Frecuencies of the Numbers
        Dictionary<int, int> numsAndCounts = new Dictionary<int, int>(nums.Length);
        foreach (int i in nums)
        {
            if (numsAndCounts.ContainsKey(i))
            {
                numsAndCounts[i]++;
            }
            else
            {
                numsAndCounts.Add(i, 1);
            }
        }


        //Convert the index to the repetion count in the array and values is the list of number that have that number of repetition
        var maximums = new List<List<int>?>(nums.Length + 1);
        for (int i = 0; i <= nums.Length; i++)
        {
            maximums.Add(null);
        }


        foreach ((var number, var numberOfAppereances) in numsAndCounts)
        {
            if (maximums[numberOfAppereances] is null)
            {
                maximums[numberOfAppereances] = new List<int>(1);
            }

            maximums[numberOfAppereances]!.Add(number);
        }


        //Values with more repetions will be at the end of the array
        var result = new int[k];
        for (int i = maximums.Count - 1; i >= 0 && k > 0; i--)
        {
            if (maximums[i] is null)
                continue;

            var curentMaximum = maximums[i]!;

            for (int j = 0; j < curentMaximum.Count && k > 0; j++)
            {
                result[k - 1] = curentMaximum[j];
                k--;
            }
        }

        return result;
    }
}


public class TopKFrequentElementsNLogKSolution : ITopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {

        Dictionary<int, int> numsAndCounts = new Dictionary<int, int>(nums.Length);

        foreach (int i in nums)
        {
            if (numsAndCounts.ContainsKey(i))
            {
                numsAndCounts[i]++;
            }
            else
            {
                numsAndCounts.Add(i, 1);
            }
        }
        var minPriorityHeapQueue = new PriorityQueue<int, int>(k);

        foreach (var item in numsAndCounts)
        {
            if (minPriorityHeapQueue.Count < k)
            {
                minPriorityHeapQueue.Enqueue(item.Key, item.Value);
            }
            else
            {
                minPriorityHeapQueue.TryPeek(out var element, out var priority);
                if (priority < item.Value)
                {
                    minPriorityHeapQueue.DequeueEnqueue(item.Key, item.Value);
                }
            }

        }

        var result = new int[k];

        while (k > 0)
        {
            result[k - 1] = minPriorityHeapQueue.Dequeue();
            k--;
        }


        return result;
    }
}



public class TopKFrequentElementsNlogNSolution : ITopKFrequentElements
{
    public int[] TopKFrequent(int[] nums, int k)
    {

        Dictionary<int, int> numsAndCounts = new Dictionary<int, int>(nums.Length);

        foreach (int i in nums)
        {
            if (numsAndCounts.ContainsKey(i))
            {
                numsAndCounts[i]++;
            }
            else
            {
                numsAndCounts.Add(i, 1);
            }
        }
        var priorityQueue = new PriorityQueue<int, int>(numsAndCounts.Count, Comparer<int>.Create((a, b) => b - a));

        foreach (var item in numsAndCounts)
        {
            priorityQueue.Enqueue(item.Key, item.Value);
        }

        var result = new int[k];

        while (k > 0)
        {
            result[k - 1] = priorityQueue.Dequeue();
            k--;
        }


        return result;
    }
}
