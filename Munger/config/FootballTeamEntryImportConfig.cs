using System.Text.RegularExpressions;

namespace DataMungingKata.config;

public class FootballTeamEntryImportConfig : IImportable
{
    public Regex RegexExpression =>
        new("^\\s+\\d+.\\s+(\\w+)\\s+\\d+\\s+\\d+\\s+\\d+\\s+\\d+\\s+(\\d+)\\s+-\\s+(\\d+)+\\s+\\d+$");

    public int[] FieldIndices => new[] { 1, 6, 8 };
}