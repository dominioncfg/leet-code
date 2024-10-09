public interface IEvaluateReversePolishNotation
{
    public int EvalRPN(string[] tokens);
}

public class EvaluateReversePolishNotation : IEvaluateReversePolishNotation
{
    const string Multiply = "*";
    const string Divide = "/";
    const string Add = "+";
    const string Subsctract = "-";
    public int EvalRPN(string[] tokens)
    {
        var operands = new Stack<int>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case Add:
                    operands.Push(operands.Pop() + operands.Pop());
                    break;
                case Subsctract:
                    var o1 = operands.Pop();
                    var o2 = operands.Pop();
                    operands.Push(-o1 + o2);
                    break;
                case Multiply:
                    operands.Push(operands.Pop() * operands.Pop());
                    break;
                case Divide:
                    var d1 = operands.Pop();
                    var d2 = operands.Pop();
                    operands.Push(d2/d1);
                   
                    break;
                 default:
                    operands.Push(int.Parse(token));
                    break;
            }
        }

        return operands.Count == 1 ? operands.Pop() : throw new Exception("Token is malformed");
    }
}
