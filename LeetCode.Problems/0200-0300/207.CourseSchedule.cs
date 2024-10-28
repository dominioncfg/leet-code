

using System.Xml.Linq;

public interface ICourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites);
}


public class CourseSchedule : ICourseSchedule
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var adjacencyList = BuildAdjacencyList(numCourses, prerequisites);

        var haveCiclesTree = TreeHaveCiclesInIt(numCourses, adjacencyList);

        return haveCiclesTree;
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

            //result[required].Add(dependant);

            result[dependant].Add(required);
        }
        return result;
    }

    private bool TreeHaveCiclesInIt(int numCourses, List<List<int>> adjacencyList)
    {

        for (int i = 0; i < numCourses; i++)
        {
            bool canTakeCourse = CanTakeCourse(adjacencyList, i);
            if (!canTakeCourse)
                return false;
        }
        return true;
    }

    private bool CanTakeCourse(List<List<int>> adjacencyList, int node, Dictionary<int, NodeState>? state = null)
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
            bool canTakeCourse = CanTakeCourse(adjacencyList, item, state);
            if (!canTakeCourse)
                return false;
        }

        state[node] = NodeState.Visited;
        return true;
    }

    private enum NodeState
    {
        UnSeen,
        Visited,
        Visiting,
    }
}