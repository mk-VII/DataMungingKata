using DataMungingKata;

namespace MungerTests;

[TestClass]
public class DataReaderTests
{
    private readonly DataReader _reader = new();
    
    [TestMethod]
    public async Task TestGetRelevantWeatherData()
    {
        var data = await _reader.GetRelevantWeatherData();

        Assert.AreEqual(data.Count(), 30);
    }
}