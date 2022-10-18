using System.Text.RegularExpressions;

namespace DataMungingKata.data;

public class Entry<T>
{
    public T Id { get; }
    private int Max { get; }
    private int Min { get; }
    public int Difference { get; }

    protected Entry(T id, int max, int min)
    {
        Id = id;
        Max = max;
        Min = min;

        Difference = Max - Min;
    }
}