using DataMungingKata;

namespace MungerTests;

[TestClass]
public class DataReaderTests
{
    private readonly DataReader _reader = new();
    
    [TestMethod]
    public async Task TestGetWeatherData()
    {
        var data = await _reader.GetWeatherData();

        Assert.AreEqual(data.Count(), 30);
    }
    
    [TestMethod]
    public async Task TestGetFootballData()
    {
        var data = await _reader.GetFootballData();

        Assert.AreEqual(data.Count(), 20);
    }
}