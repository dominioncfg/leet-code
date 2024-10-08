public interface IContainerWithMostWater
{
    public int MaxArea(int[] height);
}

public class ContainerWithMostWaterNTimeSolution : IContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        var max = 0;
        var startIndex = 0;
        var endIndex = height.Length - 1;

        while (startIndex < endIndex)
        {
            var width = endIndex - startIndex;
            var containerHeight = Math.Min(height[startIndex], height[endIndex]);

            var area = width * containerHeight;

            if (area > max)
                max = area;

            if (height[startIndex] > height[endIndex])
                endIndex--;
            else
                startIndex++;
        }
        return max;
    }
}


public class ContainerWithMostWaterBruteForceSolution : IContainerWithMostWater
{
    public int MaxArea(int[] height)
    {
        var max = 0;
        for (int startIndex = 0; startIndex < height.Length; startIndex++)
        {
            for (int endIndex = startIndex + 1; endIndex < height.Length; endIndex++)
            {
                var width = endIndex - startIndex;
                var containerHeight = Math.Min(height[startIndex], height[endIndex]);

                var area = width * containerHeight;

                if (area > max)
                    max = area;
            }
        }
        return max;
    }
}
