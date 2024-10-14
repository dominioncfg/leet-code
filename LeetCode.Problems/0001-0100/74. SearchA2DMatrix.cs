
public interface ISearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target);
}




public class SearchA2DMatrix : ISearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var l = 0L;
        var r =  (long)matrix.Length * matrix[0].Length;

        var rowLenght = matrix.Length;
        var colLenght = matrix[0].Length;

        while (l <= r)
        {
            var middle = (l + r) / 2;

            var row = middle / colLenght;
            var col = middle % colLenght;
            
            var current = matrix[row][col];

            if (current == target)
                return true;

            var shouldMoveLeft = target < current;
            if (shouldMoveLeft)
            {
                r = middle - 1;
            }
            else
            {
                l = middle + 1;
            }
        }

        return false;
    }
}

public class SearchA2DMatrixTwoSearchsSolution : ISearchA2DMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var firstDimensionLenght = matrix.Length;

        var row = FindClosestRowToInspect(matrix, target);

        if (row.Found)
            return true;

        return FindTargetInRow(matrix[row.RowToInspect], target);
    }

    private (bool Found, int RowToInspect) FindClosestRowToInspect(int[][] matrix, int target)
    {
        var l = 0L;
        var r = (long)matrix.Length - 1;

        var row = 0L;
        var minDiff = int.MaxValue; 

        while (l <= r)
        {
            var middle = (l + r) / 2;
            var current = matrix[middle][0];

            if (current == target)
                return (true, (int)middle);

            if(current<target)
            {
               var diff = target - current;
                if(diff < minDiff)
                {
                    minDiff = diff;
                    row = middle;

                }
                else return (false, (int)row);
            }

            var shouldMoveLeft = target < current;
            if (shouldMoveLeft)
            {
                r = middle - 1;
            }
            else
            {
                l = middle + 1;
            }
        }

        return (false, (int)row);
    }

    private static bool FindTargetInRow(int[] matrix, int target)
    {
        var l = 0L;
        var r = (long)matrix.Length - 1;

        while (l <= r)
        {
            var middle = (l + r) / 2;
            var current = matrix[middle];

            if (current == target)
                return true;

            var shouldMoveLeft = target <= current;
            if (shouldMoveLeft)
            {
                r = middle - 1;
            }
            else
            {
                l = middle + 1;
            }
        }

        return false;
    }


}
