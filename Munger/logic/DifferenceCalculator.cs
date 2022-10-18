using DataMungingKata.data;

namespace DataMungingKata.logic;

public static class DifferenceCalculator
{
    public static Entry<T> GetEntryWithMinimalDifference<T>(IEnumerable<Entry<T>> entries)
    {
        var orderedEntries = entries
            .Select(entry =>
                new Tuple<Entry<T>, int>(entry, entry.Difference < 0
                    ? -entry.Difference
                    : entry.Difference))
            .OrderBy(entry => entry.Item2)
            .Select(entry => entry.Item1);

        return orderedEntries.First();
    }
}