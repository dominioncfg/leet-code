namespace LeetCode.Tests;

/*
56. Merge Intervals
Medium
Topics
Companies

Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

 

Example 1:

Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

Example 2:

Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.

 

Constraints:

    1 <= intervals.length <= 10^4
    intervals[i].length == 2
    0 <= starti <= endi <= 10^4
 */

public class MergeIntervalsTests
{
    private readonly IMergeIntervals sut;
    public MergeIntervalsTests()
    {
        sut = new MergeIntervals();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);
        result.Should().NotBeNullOrEmpty();
        result[0].Should().BeEquivalentTo([1, 6], options => options.WithStrictOrdering());
        result[1].Should().BeEquivalentTo([8, 10], options => options.WithStrictOrdering());
        result[2].Should().BeEquivalentTo([15, 18], options => options.WithStrictOrdering());
    }



    [Fact]
    public void Test2()
    {
        var result = sut.Merge([[1, 4], [4, 5]]);
        result.Should().NotBeNullOrEmpty();
        result[0].Should().BeEquivalentTo([1, 5], options => options.WithStrictOrdering());
    }


    [Fact]
    public void Test3()
    {
        var result = sut.Merge([[1, 4], [0, 4]]);
        result.Should().NotBeNullOrEmpty();
        result[0].Should().BeEquivalentTo([0, 4], options => options.WithStrictOrdering());
    }


}