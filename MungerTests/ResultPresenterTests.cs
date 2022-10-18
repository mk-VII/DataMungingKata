using DataMungingKata;

namespace MungerTests;

[TestClass]
public class ResultPresenterTests
{
    private readonly ResultPresenter _presenter = new();

    [TestMethod]
    public async Task TestGetLowestSpreadDay()
    {
        var result = await _presenter.GetLowestSpreadDay();
        
        Assert.AreEqual(result, $"June 14 has the lowest difference: 2");
    }

    [TestMethod]
    public async Task TestGetLowestGoalDifference()
    {
        var result = await _presenter.GetLowestGoalDifference();
        
        Assert.AreEqual(result, "Aston_Villa has the lowest goal difference: -1");
    }
}