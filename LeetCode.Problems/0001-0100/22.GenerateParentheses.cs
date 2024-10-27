
using System.Text;

public interface IGenerateParenthesisPermutations
{
    public IList<string> GenerateParenthesis(int n);
}

public class GenerateParenthesisPermutations : IGenerateParenthesisPermutations
{
    private const char OpeningParenthesis = '(';
    private const char ClosingParenthesis = ')';
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        Backtraking(n, result);
        return result;
    }

    private void Backtraking(int n, List<string> result, List<char>? tempSolution = null, int openParenthesisSoFar = 0)
    {
        tempSolution ??= [];

        if (openParenthesisSoFar == n)
        {
            StringBuilder sb = new StringBuilder(new string([.. tempSolution]));
            while (sb.Length < n * 2)
            {
                sb.Append(ClosingParenthesis);
            }
            result.Add(sb.ToString());
            return;
        }

        if(tempSolution.Count - openParenthesisSoFar>openParenthesisSoFar)
        {
            return;
        }


        tempSolution.Add(OpeningParenthesis);
        Backtraking(n, result, tempSolution, openParenthesisSoFar + 1);
        tempSolution.RemoveAt(tempSolution.Count -1);

        tempSolution.Add(ClosingParenthesis);
        Backtraking(n, result, tempSolution, openParenthesisSoFar);
        tempSolution.RemoveAt(tempSolution.Count - 1);
    }
}