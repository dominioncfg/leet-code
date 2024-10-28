namespace LeetCode.Tests;

/*
207. Course Schedule
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.


Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: true
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0. So it is possible.

Example 2:
Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
Output: false
Explanation: There are a total of 2 courses to take. 
To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

Constraints:
    1 <= numCourses <= 2000
    0 <= prerequisites.length <= 5000
    prerequisites[i].length == 2
    0 <= ai, bi < numCourses
    All the pairs prerequisites[i] are unique.
 */

public class CourseScheduleTests
{
    private readonly ICourseSchedule sut;
    public CourseScheduleTests()
    {
        sut = new CourseSchedule();
    }

    [Fact]
    public void Test1()
    {
        var result = sut.CanFinish(2, [[1, 0]]);
        result.Should().BeTrue();
    }


    [Fact]
    public void Test2()
    {
        var result = sut.CanFinish(2, [[1, 0], [0, 1]]);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test3()
    {
        var result = sut.CanFinish(4, [[2, 0], [1, 0], [3, 1], [3, 2], [1, 3]]);
        result.Should().BeFalse();
    }


    [Fact]
    public void Test4()
    {
        var result = sut.CanFinish(4, [[0, 1], [3, 1], [1, 3], [3, 2]]);
        result.Should().BeFalse();
    }

    [Fact]
    public void Test5()
    {
        var result = sut.CanFinish(5, [[1, 4], [2, 4], [3, 1], [3, 2]]);
        result.Should().BeTrue();
    }


}