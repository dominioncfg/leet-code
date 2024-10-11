using System.Reflection;

public interface IFirstBadVersion
{
    public int FirstBadVersion(int n);

}


//Look at: while (l < r) vs (l <= r)
//and this line: if (currentIsBad){   r = middle} vs if (currentIsBad){   r = middle -1};
public class FirstBadVersionCalculatorOptimizedBinarySearchNoPointer : VersionControl, IFirstBadVersion
{
    public FirstBadVersionCalculatorOptimizedBinarySearchNoPointer(int b) : base(b)
    {

    }
    public int FirstBadVersion(int n)
    {
        var l = 1L;
        var r = (long)n;

        while (l < r)
        {
            var middle = (l + r) / 2;

            var currentIsBad = IsBadVersion((int)middle);

            if (currentIsBad)
            {
                r = middle;
            }
            else
            {
                l = middle + 1;
            }
        }

        return (int)l;
    }
}


public class FirstBadVersionCalculatorClassicBinarySearch : VersionControl, IFirstBadVersion
{
    public FirstBadVersionCalculatorClassicBinarySearch(int b) : base(b)
    {

    }
    public int FirstBadVersion(int n)
    {
        var l = 1L;
        var r = (long)n;

        var minMiddle = long.MaxValue;

        while (l <= r)
        {
            var middle = (l + r) / 2;


            var currentIsBad = IsBadVersion((int)middle);

            if (currentIsBad && minMiddle > middle)
                minMiddle = middle;


            if (currentIsBad)
            {
                r = middle - 1;


            }
            else
            {
                //Move Right Side
                l = middle + 1;
            }
        }

        return (int)minMiddle;
    }
}



public class VersionControl
{
    private readonly int badVersion;

    public VersionControl(int b)
    {
        this.badVersion = b;
    }


    protected bool IsBadVersion(int n)
    {
        return n >= badVersion;
    }
}
