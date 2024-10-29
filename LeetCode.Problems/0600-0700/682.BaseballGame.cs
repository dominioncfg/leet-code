using static System.Formats.Asn1.AsnWriter;

public interface IBaseBallGame
{
    public int CalPoints(string[] operations);
}

public class BaseBallGame : IBaseBallGame
{
    const string SumPreviousTwoScoreOperator = "+";
    const string DoublePreviousOperator = "D";
    const string InvalidatePreviousOperator = "C";

    public int CalPoints(string[] operations)
    {
        var stack = new Stack<int>();

        var sum = 0;
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case SumPreviousTwoScoreOperator:
                    var o1 = stack.Pop();
                    var newRec = o1 + stack.Peek();
                    stack.Push(o1);
                    stack.Push(newRec);
                    sum += newRec;
                    break;

                case DoublePreviousOperator:
                    var dRes = stack.Peek() * 2;
                    stack.Push(dRes);
                    sum += dRes;
                    break;

                case InvalidatePreviousOperator:
                    sum -= stack.Pop();
                    break;

                default:
                    var res = int.Parse(operation);
                    stack.Push(res);
                    sum += res;
                    break;
            }
        }

        return sum;
    }
}