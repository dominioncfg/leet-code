public interface ISquaresOfASortedArray
{
    public int[] SortedSquares(int[] nums);
}

public class SquaresOfASortedArray : ISquaresOfASortedArray
{
    public int[] SortedSquares(int[] nums)
    {
        var squares = new int[nums.Length];
        
        for (int i = 0; i < nums.Length; i++)
        {
            squares[i] = nums[i] * nums[i];
        }

        var result = new int[squares.Length];
        var leftIndex = 0;
        var rightIndex = squares.Length - 1;
        var resultArrayIndex = squares.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var left = squares[leftIndex];
            var right = squares[rightIndex];

            if (left > right)
            {
                result[resultArrayIndex] = left;
                leftIndex++;
            }
            else
            {
                result[resultArrayIndex] = right;
                rightIndex--;
            }
            resultArrayIndex--;
        }


        return result;
    }
}

public class SquaresOfASortedArrayTrivialSolution : ISquaresOfASortedArray
{
    public int[] SortedSquares(int[] nums)
    {
        return nums.Select(x => x * x).OrderBy(x => x).ToArray();
    }
}
