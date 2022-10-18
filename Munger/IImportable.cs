using System.Text.RegularExpressions;

namespace DataMungingKata;

public interface IImportable
{
    Regex RegexExpression { get; }
    int[] FieldIndices { get; }
}