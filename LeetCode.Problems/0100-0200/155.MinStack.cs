public class MinStack
{
    private StackNode? _top;

    public MinStack()
    {

    }

    public void Push(int val)
    {
        var min = Math.Min(val, (_top?.MinSoFar ?? int.MaxValue));
        var newTop = new StackNode(val, min, _top);
        _top = newTop;
    }

    public void Pop()
    {
        _top = _top?.Next;
    }

    public int Top()
    {
        return _top?.Value ?? 0;
    }

    public int GetMin()
    {
        return _top?.MinSoFar ?? 0;
    }

    private class StackNode
    {
        public int Value { get; }
        public int MinSoFar { get; }
        public StackNode? Next { get; private set; }

        public StackNode(int value, int minSoFar, StackNode? next = null)
        {
            Value = value;
            MinSoFar = minSoFar;
            Next = next;
        }
    }
}

