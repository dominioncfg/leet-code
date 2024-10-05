namespace LeetCode.Tests;

/*

54. Spiral Matrix
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:

Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 10
    -100 <= matrix[i][j] <= 100
 */

public class SpiralMatrixTests
{
    private readonly IsSpiralMatrix sut;
    public SpiralMatrixTests()
    {
        sut = new IsSpiralMatrix();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.SpiralOrder([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
        result.Should().BeEquivalentTo([1, 2, 3, 6, 9, 8, 7, 4, 5], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.SpiralOrder([[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]);
        result.Should().BeEquivalentTo([1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test3()
    {
        var result = sut.SpiralOrder([[1, 2, 3]]);
        result.Should().BeEquivalentTo([1, 2, 3], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test4()
    {
        var result = sut.SpiralOrder([[1], [2], [3]]);
        result.Should().BeEquivalentTo([1, 2, 3], options => options.WithStrictOrdering());
    }

}