using System.Text.RegularExpressions;
using DataMungingKata.data;

namespace DataMungingKata;

public class WeatherEntry : Entry<int>
{
    public WeatherEntry(int number, int max, int min) : base(number, max, min)
    {
    }

    public static WeatherEntry CreateEntry(string dataLine, IEnumerable<int> indices)
    {
        var entryFields = GetValuesForIndices(dataLine, indices).ToList();

        return new WeatherEntry(
            int.Parse(entryFields[0]),
            int.Parse(Regex.Replace(entryFields[1], "[^0-9]", "")),
            int.Parse(Regex.Replace(entryFields[2], "[^0-9]", ""))
        );
    }
}