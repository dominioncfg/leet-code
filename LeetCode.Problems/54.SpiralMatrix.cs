using System;

public interface IIsSpiralMatrix

{
    public IList<int> SpiralOrder(int[][] matrix);
}

internal enum Direction
{
    Right,
    Down,
    Left,
    Up
}

internal static class DurationExtensions
{
    internal static Direction Next(this Direction d)
    {
        if (d is Direction.Up)
            return Direction.Right;

        if (d is Direction.Right)
            return Direction.Down;

        if (d is Direction.Down)
            return Direction.Left;

        if (d is Direction.Left)
            return Direction.Up;

        throw new ArgumentException("not gonna happen");
    }
}

public class IsSpiralMatrix : IIsSpiralMatrix
{



    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        var numberOfRows = matrix.Length;
        var numberOfColumns = matrix[0].Length;

        int upWall = 1;
        int leftWall = 0;

        int rightWall = numberOfColumns;
        int downWall = numberOfRows;

        Direction direction = Direction.Right;

        int r = 0;
        int c = 0;

        while (result.Count < numberOfRows * numberOfColumns)
        {
            switch (direction)
            {
                case Direction.Right:
                    while (c < rightWall)
                    {
                        result.Add(matrix[r][c]);
                        c++;
                    }
                    r++;
                    c--;
                    rightWall--;
                    direction = direction.Next();
                    break;
                case Direction.Down:
                    while (r < downWall)
                    {
                        result.Add(matrix[r][c]);
                        r++;
                    }
                    c--;
                    r--;
                    downWall--;
                    direction = direction.Next();
                    break;
                case Direction.Left:
                    while (c >= leftWall)
                    {
                        result.Add(matrix[r][c]);
                        c--;
                    }
                    c++;
                    r--;
                    leftWall++;
                    direction = direction.Next();
                    break;
                case Direction.Up:
                    while (r >= upWall)
                    {
                        result.Add(matrix[r][c]);
                        r--;
                    }
                    c++;
                    r++;
                    upWall++;
                    direction = direction.Next();
                    break;
            }

        }

        return result;
    }
}
