using System.Text.RegularExpressions;

namespace DataMungingKata;

public interface IImportConfig
{
    Regex RegexExpression { get; }
    int[] FieldIndices { get; }
}