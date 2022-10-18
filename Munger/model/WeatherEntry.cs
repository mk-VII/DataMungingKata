using DataMungingKata.data;

namespace DataMungingKata;

public class WeatherEntry : Entry<int>
{
    public WeatherEntry(int number, int max, int min) : base(number, max, min) {}
}