using DataMungingKata.logic;

namespace DataMungingKata;

public class ResultPresenter
{
    private readonly DataReader _dataReader = new();
    
    public async Task<string> GetLowestSpreadDay()
    {
        var resultData = await _dataReader.GetWeatherData();

        var lowestDifferenceEntry = DifferenceCalculator.GetEntryWithMinimalDifference(resultData);

        return $"June {lowestDifferenceEntry.Id} has the lowest difference: {lowestDifferenceEntry.Difference}";
    }

    public async Task<string> GetLowestGoalDifference()
    {
        var resultData = await _dataReader.GetFootballData();

        var lowestDifferenceEntry = DifferenceCalculator.GetEntryWithMinimalDifference(resultData);

        return $"{lowestDifferenceEntry.Id} has the lowest goal difference: {lowestDifferenceEntry.Difference}";
    }
}