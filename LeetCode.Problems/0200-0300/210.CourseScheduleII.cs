public interface ICourseScheduleII
{
    public int[] FindOrder(int numCourses, int[][] prerequisites);
}


public class CourseScheduleII : ICourseScheduleII
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var adjacencyList = BuildAdjacencyList(numCourses, prerequisites);

        var result = GetCoursesInOrder(numCourses, adjacencyList);

        return result;
    }

    private List<List<int>> BuildAdjacencyList(int numCourses, int[][] prerequisites)
    {
        var result = new List<List<int>>(numCourses);

        for (int i = 0; i < numCourses; i++)
        {
            result.Add([]);
        }

        foreach (var edge in prerequisites)
        {
            var dependant = edge[0];
            var required = edge[1];

            result[dependant].Add(required);
        }
        return result;
    }

    private int[] GetCoursesInOrder(int numCourses, List<List<int>> adjacencyList)
    {
        var result = new List<int>();
        var state = new Dictionary<int, NodeState>();
        for (int i = 0; i < numCourses; i++)
        {
            bool canTakeCourse = CanTakeCourse(adjacencyList, i, result, state);
            if (!canTakeCourse)
                return [];
        }
        return [.. result];
    }

    private bool CanTakeCourse(List<List<int>> adjacencyList, int node, List<int> coursesContainer, Dictionary<int, NodeState>? state)
    {
        state = state ?? new Dictionary<int, NodeState>();


        if (state.ContainsKey(node) && state[node] == NodeState.Visited)
            return true;


        if (state.ContainsKey(node) && state[node] == NodeState.Visiting)
            return false;


        state[node] = NodeState.Visiting;

        var adjacents = adjacencyList[node];
        foreach (var item in adjacents)
        {
            bool canTakeCourse = CanTakeCourse(adjacencyList, item, coursesContainer, state);
            if (!canTakeCourse)
                return false;
        }

        state[node] = NodeState.Visited;
        coursesContainer.Add(node);
        return true;
    }

    private enum NodeState
    {
        UnSeen,
        Visited,
        Visiting,
    }
}