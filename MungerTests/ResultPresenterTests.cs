using DataMungingKata;

namespace MungerTests;

[TestClass]
public class ResultPresenterTests
{
    [TestMethod]
    public async Task TestGetLowestSpreadDay()
    {
        var presenter = new ResultPresenter();

        var dayNumberResult = await presenter.GetLowestSpreadDay();
        
        Assert.AreEqual(dayNumberResult, 14);
    }
}