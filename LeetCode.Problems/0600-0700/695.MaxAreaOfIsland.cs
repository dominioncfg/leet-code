
public interface IFindMaxAreaOfIsland
{
    public int MaxAreaOfIsland(int[][] grid);
}

public class FindMaxAreaOfIsland : IFindMaxAreaOfIsland
{
    public int MaxAreaOfIsland(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var maxAreaSoFar = 0;
        for (var mI = 0; mI < m; mI++)
        {
            for (var nI = 0; nI < n; nI++)
            {
                if (IsWater(grid[mI][nI]))
                    continue;

                var area = CountAndMarkIsland(grid, (mI, nI));
                if (area > maxAreaSoFar)
                    maxAreaSoFar = area;
            }
        }

        return maxAreaSoFar;
    }



    private int CountAndMarkIsland(int[][] grid, (int X, int Y) position)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        if (position.X < 0 || position.X >= m)
            return 0;

        if (position.Y < 0 || position.Y >= n)
            return 0;

        if (IsWater(grid[position.X][position.Y]))
            return 0;

        grid[position.X][position.Y] = _water;

        var cleft = CountAndMarkIsland(grid, (position.X - 1, position.Y));
        var cRight = CountAndMarkIsland(grid, (position.X + 1, position.Y));
        var cTop = CountAndMarkIsland(grid, (position.X, position.Y - 1));
        var cDown = CountAndMarkIsland(grid, (position.X, position.Y + 1));

        return cleft + cRight + cTop + cDown + 1;
    }

    private const int _water = 0;
    private bool IsWater(int w) => w == _water;
}