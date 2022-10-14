namespace DataMungingKata;

public class DataReader
{
    public async Task<IEnumerable<WeatherData>> GetRelevantWeatherData()
    {
        var lines = await ReadInAllLines();

        foreach (var line in lines)
        {
            var dayNumber = ReadInDayNumber(line);
        }

        return new List<WeatherData>();
    }

    private async Task<IEnumerable<string>> ReadInAllLines()
    {
        return await File.ReadAllLinesAsync("data/weather.dat");
    }
    
    private int ReadInDayNumber(string dataLine)
    {
        return 0;
    }
}