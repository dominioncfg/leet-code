
public interface ISodukuValidator
{
    public bool IsValidSudoku(char[][] board);
}

public class SodukuMulltipleHashesValidator : ISodukuValidator
{
    public bool IsValidSudoku(char[][] board)
    {
        var rowsDictionary = new Dictionary<int, HashSet<int>>();
        var columnsDictionary = new Dictionary<int, HashSet<int>>();
        var boxesDictionary = new Dictionary<int, HashSet<int>>();

        InitializeData(board.Length, rowsDictionary, columnsDictionary, boxesDictionary);

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                var current = board[row][col];

                if (!char.IsDigit(current))
                    continue;

                var currentValue = (int)char.GetNumericValue(current);

                var boxPositionLeft = (row) / 3;
                var boxPositionRight = (col) / 3;


                var boxPostion = boxPositionLeft * 3 + boxPositionRight;

                var addToRowResult = rowsDictionary[row].Add(currentValue);
                var addToColResult = columnsDictionary[col].Add(currentValue);
                var addToBoxResult = boxesDictionary[boxPostion].Add(currentValue);


                if (!addToRowResult || !addToColResult || !addToBoxResult)
                    return false;
            }
        }

        return true;
    }

    private static void InitializeData(int boardLenght, Dictionary<int, HashSet<int>> rowsDictionary, Dictionary<int, HashSet<int>> columnsDictionary, Dictionary<int, HashSet<int>> boxesDictionary)
    {
        var elements = Enumerable
                    .Range(0, boardLenght)
                    .ToList();

        foreach (var element in elements)
        {
            rowsDictionary.Add(element, new HashSet<int>());
            columnsDictionary.Add(element, new HashSet<int>());
            boxesDictionary.Add(element, new HashSet<int>());
        }
    }
}


public class SodukuSingleHashValidator : ISodukuValidator
{
    public bool IsValidSudoku(char[][] board)
    {
        var uniqueContainer = new HashSet<string>();

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                var current = board[row][col];

                if (current == '.')
                    continue;

                var boxPositionLeft = (row) / 3;
                var boxPositionRight = (col) / 3;
                var boxPostion = boxPositionLeft * 3 + boxPositionRight;

                var addToRowResult = uniqueContainer.Add($"r{row}-{current}");
                if (!addToRowResult)
                    return false;
                
                var addToColResult = uniqueContainer.Add($"c{col}-{current}");
                if (!addToColResult)
                    return false;
                
                var addToBoxResult = uniqueContainer.Add($"b{boxPostion}-{current}");
                if (!addToBoxResult)
                    return false;
            }
        }

        return true;
    }
}
