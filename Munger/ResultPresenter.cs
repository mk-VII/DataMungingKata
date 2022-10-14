namespace DataMungingKata;

public class ResultPresenter
{
    private readonly DataReader _dataReader = new();
    
    public async Task<int> GetLowestSpreadDay()
    {
        var resultData = await _dataReader.GetRelevantWeatherData();

        var lowestSpreadDay = resultData.OrderBy(x => x.Difference);

        return lowestSpreadDay.First().DayNumber;
    }
}