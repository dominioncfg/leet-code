public interface IValidPerfectSquare
{
    public bool IsPerfectSquare(int num);
}

public class ValidPerfectSquare : IValidPerfectSquare
{
    public bool IsPerfectSquare(int num)
    {
        var l = 1L;
        var r = (long)num;


        while (l <= r)
        {
            var middle = (l + r) / 2;

            var current = middle * middle;

            if(current == num)
                return true;

            if(current>num)
            {
                r = middle - 1;
            }
            else
            {
                l = middle + 1;
            }
        }

        return false;
    }
}
