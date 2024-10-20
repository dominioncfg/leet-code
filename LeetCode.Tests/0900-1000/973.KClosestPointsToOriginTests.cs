namespace LeetCode.Tests;

/*
Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, return the k closest points to the origin (0, 0).
The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)2 + (y1 - y2)2).
You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).

Example 1:
Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Explanation:
The distance between (1, 3) and the origin is sqrt(10).
The distance between (-2, 2) and the origin is sqrt(8).
Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].

Example 2:
Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]
Explanation: The answer [[-2,4],[3,3]] would also be accepted.

Constraints:

    1 <= k <= points.length <= 10^4
    -10^4 <= Xi, Yi <= 10^4
 */

public class KClosestPointsToOriginTests
{
    private readonly IKClosestPointsToOrigin sut;
    public KClosestPointsToOriginTests()
    {
        sut = new KClosestPointsToOrigin();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.KClosest([[1, 3], [-2, 2]],1);
        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo([-2, 2], options => options.WithStrictOrdering());
    }

    [Fact]
    public void Test2()
    {
        var result = sut.KClosest([[3, 3], [5, -1], [-2, 4]], 2);
        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf<int[]>([3, 3],options=>options.WithStrictOrdering());
        result.Should().ContainEquivalentOf<int[]>([-2, 4], options => options.WithStrictOrdering());
    }
}