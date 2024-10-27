

public interface IWordSearch
{
    public bool Exist(char[][] board, string word);
}


public class WordSearch : IWordSearch
{
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;

        var startOfWord = word[0];
        for (int iM = 0; iM < m; iM++)
        {
            for (var jN = 0; jN < n; jN++)
            {
                if (SearchWordRecursively(board, word, (iM, jN)))
                    return true;
            }
        }
        return false;
    }

    private bool SearchWordRecursively(char[][] board, string word, (int Row, int Column) position, int wordIndex = 0)
    {
        var m = board.Length;
        var n = board[0].Length;

        if (wordIndex == word.Length)
            return true;

        if (position.Row < 0 || position.Row >= m)
            return false;

        if (position.Column < 0 || position.Column >= n)
            return false;

        if (board[position.Row][position.Column] != word[wordIndex])
            return false;


        board[position.Row][position.Column] = '#';

        if (SearchWordRecursively(board, word, (position.Row - 1, position.Column), wordIndex + 1))
            return true;

        if (SearchWordRecursively(board, word, (position.Row + 1, position.Column), wordIndex + 1))
            return true;

        if (SearchWordRecursively(board, word, (position.Row, position.Column - 1), wordIndex + 1))
            return true;

        if (SearchWordRecursively(board, word, (position.Row, position.Column + 1), wordIndex + 1))
            return true;

        board[position.Row][position.Column] = word[wordIndex];

        return false;
    }

   
}

