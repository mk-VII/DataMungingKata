using System.Text.RegularExpressions;

namespace DataMungingKata.config;

public class WeatherEntryImportConfig : IImportConfig
{
    public Regex RegexExpression =>
        new("^ +(\\d+) +(\\d+)*? +(\\d+)*?.+$");

    public int[] FieldIndices => new[] { 0, 1, 2 };
}