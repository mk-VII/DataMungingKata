using DataMungingKata;
using DataMungingKata.data;
using DataMungingKata.logic;

namespace MungerTests.logic;

[TestClass]
public class DifferenceCalculatorTests
{
    [DataRow(new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
    [DataTestMethod]
    public void TestGetEntryWithMinimalDifference(int[] maxValues, int[] minValues)
    {
        var entries = maxValues.Select(
            (maxValue, index) => 
                new WeatherEntry(index, maxValue, minValues[index]));

        var lowestDiffEntry = DifferenceCalculator.GetEntryWithMinimalDifference(entries);
        
        Assert.AreEqual(lowestDiffEntry.Difference, 1);
    }
}