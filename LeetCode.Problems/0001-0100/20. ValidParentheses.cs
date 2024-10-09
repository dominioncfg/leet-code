public interface IValidParentheses
{
    public bool IsValid(string s);
}

public class ValidParentheses : IValidParentheses
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            var isClosingChar = c == ']' || c == ')' || c == '}';
            if (isClosingChar)
            {
                if(stack.Count == 0)
                    return false;

                var opening = stack.Pop();
                if(!Correspond(opening,c))
                    return false;
            }
            else 
                stack.Push(c);
        }

        return stack.Count == 0;
    }

    private bool Correspond(char openingSign, char closingSign)
    {
        if (openingSign == '[' && closingSign == ']')
            return true;

        if (openingSign == '(' && closingSign == ')')
            return true;

        if (openingSign == '{' && closingSign == '}')
            return true;

        return false;
    }
}
