using System.Text.RegularExpressions;
using DataMungingKata.config;
using DataMungingKata.data;

namespace DataMungingKata;

public class DataReader
{
    public static async Task<IEnumerable<WeatherEntry>> GetWeatherData()
    {
        var importConfig = new WeatherEntryImportConfig();
        
        var lines = (await File.ReadAllLinesAsync(
                @"..\..\..\..\Munger\data\weather.dat"))
            .ToList();

        return lines
            .Where(line => importConfig.RegexExpression.IsMatch(line))
            .Select(line => WeatherEntry.CreateEntry(line, importConfig.FieldIndices));
    }

    public static async Task<IEnumerable<FootballTeamEntry>> GetFootballData()
    {
        var importConfig = new FootballTeamEntryImportConfig();

        var lines = (await File.ReadAllLinesAsync(
                @"..\..\..\..\Munger\data\football.dat"))
            .ToList();

        return lines
            .Where(line => importConfig.RegexExpression.IsMatch(line))
            .Select(line => FootballTeamEntry.CreateEntry(line, importConfig.FieldIndices));
    }
}