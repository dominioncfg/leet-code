
public interface IRottingOranges
{
    public int OrangesRotting(int[][] grid);
}

public class RottingOranges : IRottingOranges
{
    private const int _freshOrange = 1;
    private const int _rootedOrange = 2;
    private static readonly (int, int) _fullStop = (-1, -1);

    public int OrangesRotting(int[][] grid)
    {
        var (rootedOranges, freshOranges) = GetOrangesInitialState(grid);
        return RootOranges(grid, rootedOranges, freshOranges);
    }



    private (Queue<(int M, int N)> RootedOranges, int FreshOranges) GetOrangesInitialState(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rootedOranges = new Queue<(int, int)>();
        var countOfFreshOranges = 0;

        for (var mI = 0; mI < m; mI++)
        {
            for (var nI = 0; nI < n; nI++)
            {
                var row = grid[mI][nI];
                if (row == _rootedOrange)
                {
                    rootedOranges.Enqueue((mI, nI));
                }
                else if (row == _freshOrange)
                {
                    countOfFreshOranges++;
                }
            }
        }
        return (rootedOranges, countOfFreshOranges);
    }

    private static int RootOranges(int[][] grid, Queue<(int M, int N)> rootedOranges, int freshOranges)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        if (freshOranges == 0)
            return 0;

        if (rootedOranges.Count == 0)
            return -1;


        int countOfIterations = 1;
        rootedOranges.Enqueue(_fullStop);

        while (rootedOranges.Count > 0 && freshOranges > 0)
        {
            var position = rootedOranges.Dequeue();

            if (position == _fullStop)
            {
                countOfIterations++;

                if (rootedOranges.Count == 0)
                    break;

                rootedOranges.Enqueue(_fullStop);
                continue;
            }

            var lookupPositon = (List<(int M, int N)>)
                [
                    (position.M, position.N +1),
                    (position.M, position.N -1),
                    (position.M +1, position.N),
                    (position.M -1, position.N),
                ];

            foreach (var searchPosition in lookupPositon)
            {
                if (searchPosition.N < 0 || searchPosition.N >= n)
                    continue;

                if (searchPosition.M < 0 || searchPosition.M >= m)
                    continue;

                var positionValue = grid[searchPosition.M][searchPosition.N];

                if (positionValue != _freshOrange)
                    continue;

                grid[searchPosition.M][searchPosition.N] = _rootedOrange;
                rootedOranges.Enqueue(searchPosition);
                freshOranges--;
            }
        }
        return freshOranges > 0 ? -1 : countOfIterations;
    }
}
