using System.Text.RegularExpressions;
using DataMungingKata.config;

namespace DataMungingKata;

public class DataReader
{
    public async Task<IEnumerable<WeatherEntry>> GetWeatherData()
    {
        var lines = (await File.ReadAllLinesAsync(
                @"C:\Users\Mark.Scholefield\Repos\Development Plan\DataMungingKata\Munger\data\weather.dat"))
            .ToList();

        return lines
            .Where(IsValidDataLine)
            .Select(ParseToWeatherData);
    }

    public async Task<IEnumerable<FootballTeamEntry>> GetFootballData()
    {
        var importConfig = new FootballTeamEntryImportConfig();

        var lines = (await File.ReadAllLinesAsync(
                @"C:\Users\Mark.Scholefield\Repos\Development Plan\DataMungingKata\Munger\data\football.dat"))
            .ToList();

        var entries = lines
            .Where(line => importConfig.RegexExpression.IsMatch(line))
            .Select(line => FootballTeamEntry.CreateEntry(line, importConfig.FieldIndices));

        return entries;
    }

    private bool IsValidDataLine(string dataLine)
    {
        return !string.IsNullOrEmpty(dataLine) && int.TryParse(ReadInNextValue(dataLine), out _);
    }

    private WeatherEntry ParseToWeatherData(string dataLine)
    {
        var (dayNumber, updatedLine1) = SeparateNextNumericValueFromString(dataLine);
        var (maxTempNumber, updatedLine2) = SeparateNextNumericValueFromString(updatedLine1);
        var (minTempNumber, _) = SeparateNextNumericValueFromString(updatedLine2);

        return new WeatherEntry(dayNumber, maxTempNumber, minTempNumber);
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