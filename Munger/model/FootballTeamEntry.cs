using System.Text.RegularExpressions;
using DataMungingKata.data;

namespace DataMungingKata;

public class FootballTeamEntry : Entry<string>
{
    private FootballTeamEntry(string name, int max, int min) : base(name, max, min)
    {
    }

    public static FootballTeamEntry CreateEntry(string dataLine, IEnumerable<int> indices)
    {
        var entryFields = GetValuesForIndices(dataLine, indices).ToList();

        return new FootballTeamEntry(
            entryFields[0],
            int.Parse(entryFields[1]),
            int.Parse(entryFields[2])
        );
    }
}