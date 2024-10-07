public interface IStringReverser
{
    public void ReverseString(char[] s);
}

public class StringReverser : IStringReverser
{
    public void ReverseString(char[] s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            var secondIndex = s.Length -1 - i;

            var tmp = s[i];
            s[i] = s[secondIndex];
            s[secondIndex] = tmp;
        }
    }
}
