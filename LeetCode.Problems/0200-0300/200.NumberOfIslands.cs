
public interface INumberOfIslands
{
    public int NumIslands(char[][] grid);
}


public class NumberOfIslands : INumberOfIslands
{
    public int NumIslands(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var numberOfIslands = 0;
        for (int mI = 0; mI < m; mI++)
        {
            for (var nI = 0; nI < n; nI++)
            {
                if (IsWater(grid[mI][nI]))
                    continue;

                MarkIsland(grid, (mI, nI));
                numberOfIslands++;
            }
        }

        return numberOfIslands;
    }

    private void MarkIsland(char[][] grid, (int X, int Y) position)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        if (position.X < 0 || position.X >= m)
            return;

        if (position.Y < 0 || position.Y >= n)
            return;

        if (IsWater(grid[position.X][position.Y]))
            return;

        grid[position.X][position.Y] = Water;

        MarkIsland(grid, (position.X - 1, position.Y));
        MarkIsland(grid, (position.X + 1, position.Y));
        MarkIsland(grid, (position.X, position.Y - 1));
        MarkIsland(grid, (position.X, position.Y + 1));
    }

    private static List<List<int>> GetAdjacencyList(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var result = new List<List<int>>(m * n);

        for (int mI = 0; mI < m * n; mI++)
        {
            result.Add(new List<int>());
        }

        for (int mI = 0; mI < m; mI++)
        {
            for (var nI = 0; nI < n; nI++)
            {
                if (IsWater(grid[mI][nI]))
                    continue;


            }
        }
        return result;
    }


    private const char Water = '0';
    private static bool IsWater(char c) => c == Water;
}