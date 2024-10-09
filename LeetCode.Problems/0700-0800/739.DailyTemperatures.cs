public interface IDailyTemperaturesCalculator
{
    public int[] DailyTemperatures(int[] temperatures);
}

public class DailyTemperaturesCalculator : IDailyTemperaturesCalculator
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var pendingTemperatures = new Stack<(int Temperature, int Index)>(temperatures.Length);
        
        var result = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            int currentTemperature = temperatures[i];
            while (pendingTemperatures.Count>0 && pendingTemperatures.Peek().Temperature< currentTemperature)
            {
                var worstDay = pendingTemperatures.Pop();
                result[worstDay.Index] = i - worstDay.Index;
            }
            pendingTemperatures.Push((currentTemperature, i));
        }

        return result;
    }
}
