using DataMungingKata;

namespace MungerTests;

[TestClass]
public class DataReaderTests
{
    private readonly DataReader _reader = new();
    
    [TestMethod]
    public async Task TestGetWeatherData()
    {
        var data = await DataReader.GetWeatherData();

        Assert.AreEqual(30, data.Count());
    }
    
    [TestMethod]
    public async Task TestGetFootballData()
    {
        var data = await DataReader.GetFootballData();

        Assert.AreEqual(20, data.Count());
    }
}