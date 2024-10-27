namespace LeetCode.Tests;

/*
79. Word Search
Given an m x n grid of characters board and a string word, return true if word exists in the grid.
The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

 

Example 1:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true

Example 2:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true

Example 3:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false

Constraints:
    m == board.length
    n = board[i].length
    1 <= m, n <= 6
    1 <= word.length <= 15
    board and word consists of only lowercase and uppercase English letters.
Follow up: Could you use search pruning to make your solution faster with a larger board?
 */

public class WordSearchTests
{
    private readonly IWordSearch sut;
    public WordSearchTests()
    {
        sut = new WordSearch();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCCED");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "SEE");
        result.Should().BeTrue();
    }

    [Fact]
    public void Test3ShouldNotReturnBack()
    {
        var result = sut.Exist([['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']], "ABCB");
        result.Should().BeFalse();
    }

    [Fact]
    public void Test4HereThereIsACicle()
    {
        var result = sut.Exist([['a', 'a', 'a', 'a'], ['a', 'a', 'a', 'a'], ['a', 'a', 'a', 'a']], "aaaaaaaaaaaaa");
        result.Should().BeFalse();
    }


    [Fact]
    public void Test5HTimeLimitExceeded()
    {
        var result = sut.Exist([['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'A'], ['A', 'A', 'A', 'A', 'A', 'B'], ['A', 'A', 'A', 'A', 'B', 'A']], "AAAAAAAAAAAAABB");
        result.Should().BeFalse();
    }
}