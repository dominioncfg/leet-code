public interface IValidPalindrome
{
    public bool IsPalindrome(string s);
}

public class ValidPalindrome : IValidPalindrome
{
    public bool IsPalindrome(string s)
    {
        int cLeftIndex = 0;
        int cRightIndex = s.Length - 1;

        while (cLeftIndex < cRightIndex)
        {
            while (cLeftIndex < cRightIndex && !char.IsLetter(s[cLeftIndex]) && !char.IsDigit(s[cLeftIndex]))
            {
                cLeftIndex++;


            }
            while (cLeftIndex < cRightIndex && !char.IsLetter(s[cRightIndex]) && !char.IsDigit(s[cRightIndex]))
            {
                cRightIndex--;
            }

            if (cLeftIndex > cRightIndex)
                break;

            var left = s[cLeftIndex];
            var right = s[cRightIndex];
            if (char.ToLower(left) != char.ToLower(right))
                return false;

            cLeftIndex++;
            cRightIndex--;

        }

        return true;
    }
}

