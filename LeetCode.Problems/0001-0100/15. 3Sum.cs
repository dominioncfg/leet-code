public interface IThreeSumCalculator
{
    public IList<IList<int>> ThreeSum(int[] nums);
}

public class ThreeSumCalculator : IThreeSumCalculator
{
    //[-1,0,1,2,-1,-4]
    public IList<IList<int>> ThreeSum(int[] nums)
    {

        var dict = new Dictionary<int, int>();

        var result = new HashSet<(int, int, int)>();

        for (int i = 0; i < nums.Length; i++)
        {
            dict[nums[i]] = i;
        }


        for (int i = 0; i < nums.Length - 2; i++)
        {
            var number = nums[i];

            for (var j = i + 1; j < nums.Length; j++)
            {
                var thirdCandidate = nums[j];

                var required = -number - thirdCandidate;

                if (dict.ContainsKey(required) && dict[required] != i && dict[required] != j)
                {
                    var sorted = new int[] { number, required, thirdCandidate };
                    Array.Sort(sorted);
                    var tuple = new ValueTuple<int, int, int>(sorted[0], sorted[1], sorted[2]);
                    result.Add(tuple);
                }
            }

        }

        var sometething = result.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3}).ToList();
        return sometething;
    }
}

//There is a better solution by sorting the array.