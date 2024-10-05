
public interface IRotateImage
{
    public void Rotate(int[][] matrix);
}

public class RotateImage : IRotateImage
{
    public void Rotate(int[][] matrix)
    {
        if (matrix.Length == 1)
            return;
        TransposeSquareMatrixInPlace(matrix);

        //var transposed = string.Join(Environment.NewLine, matrix.Select(x => $"[{string.Join(",", x)}]"));

        ReflectSquareMatrixInPlace(matrix);

        //var transposed = string.Join(Environment.NewLine, matrix.Select(x => $"[{string.Join(",", x)}]"));
    }

    private void TransposeSquareMatrixInPlace(int[][] matrix)
    {
        var n = matrix.Length;
        for (int diagonalIndex = 1; diagonalIndex < n; diagonalIndex++)
        {
            for (int j = 0; j < diagonalIndex; j++)
            {
                var belowDiabonalPosition = matrix[diagonalIndex][j];
                matrix[diagonalIndex][j] = matrix[j][diagonalIndex];
                matrix[j][diagonalIndex] = belowDiabonalPosition;
            }
        }
    }

    private void ReflectSquareMatrixInPlace(int[][] matrix)
    {
        var n = matrix.Length;
        var half = Math.Ceiling((double)n / 2);

        for (int rowIndex = 0; rowIndex < n; rowIndex++)
        {
            
            for (int j = 0; j < half; j++)
            {
                var right = matrix[rowIndex][n - 1 -j];
                matrix[rowIndex][n - 1 - j] =  matrix[rowIndex][j];
                matrix[rowIndex][j] = right;
            }
        }
    }
}
