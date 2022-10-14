using System.Text.RegularExpressions;

namespace DataMungingKata;

public class DataReader
{
    public async Task<IEnumerable<WeatherData>> GetRelevantWeatherData()
    {
        var lines = (await ReadInAllLines()).ToList();

        return lines
            .Where(IsValidDataLine)
            .Select(ParseToWeatherData);
    }

    private async Task<IEnumerable<string>> ReadInAllLines()
    {
        return await File.ReadAllLinesAsync(
            @"C:\Users\Mark.Scholefield\Repos\Development Plan\DataMungingKata\Munger\data\weather.dat");
    }

    private bool IsValidDataLine(string dataLine)
    {
        return !string.IsNullOrEmpty(dataLine) && int.TryParse(ReadInNextValue(dataLine), out _);
    }

    private WeatherData ParseToWeatherData(string dataLine)
    {
        var (dayNumber, updatedLine1) = SeparateNextNumericValueFromString(dataLine);
        var (maxTempNumber, updatedLine2) = SeparateNextNumericValueFromString(updatedLine1);
        var (minTempNumber, _) = SeparateNextNumericValueFromString(updatedLine2);

        return new WeatherData(dayNumber, maxTempNumber, minTempNumber);
    }

    private (int, string) SeparateNextNumericValueFromString(string dataLine)
    {
        var value = ReadInNextValue(dataLine);

        return (
            int.Parse(Regex.Replace(value, "[^0-9]", "")),
            RemoveValueFromString(value, dataLine)
        );
    }

    private static string ReadInNextValue(string dataLine)
    {
        var value = string.Empty;

        var pos = 0;
        while (dataLine[pos] == ' ')
        {
            pos++;
        }

        while (dataLine[pos] != ' ')
        {
            value += dataLine[pos];
            pos++;
        }

        return value;
    }

    private static string RemoveValueFromString(string value, string dataLine)
    {
        var indexOfValue = dataLine.IndexOf(value, StringComparison.Ordinal);
        var removeCount = indexOfValue + value.Length;

        return dataLine.Remove(0, removeCount);
    }
}