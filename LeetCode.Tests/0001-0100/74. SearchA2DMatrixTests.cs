namespace LeetCode.Tests;

/*
74. Search a 2D Matrix

You are given an m x n integer matrix matrix with the following two properties:
    Each row is sorted in non-decreasing order.
    The first integer of each row is greater than the last integer of the previous row.

Given an integer target, return true if target is in matrix or false otherwise.
You must write a solution in O(log(m * n)) time complexity.

Example 1:
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true

Example 2:
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false

Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 100
    -10^4 <= matrix[i][j], target <= 10^4
 */

public class SearchA2DMatrixTests
{
    private readonly ISearchA2DMatrix sut;
    public SearchA2DMatrixTests()
    {
        sut = new SearchA2DMatrix();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]],3);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        var result = sut.SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 60]], 13);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.SearchMatrix([[1, 3, 5, 7], [10, 11, 16, 20], [23, 30, 34, 50]], 11);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test4()
    {
        var result = sut.SearchMatrix([[1, 3]], 3);
        result.Should().BeTrue();
    }

    [Fact]
    public void Test5()
    {
        var result = sut.SearchMatrix([[1],[3]], 3);
        result.Should().BeTrue();
    }

}