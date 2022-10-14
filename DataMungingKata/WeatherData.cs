namespace DataMungingKata;

public class WeatherData
{
    public int DayNumber { get; set; }
    public int MaxTemp { get; set; }
    public int MinTemp { get; set; }

    public WeatherData(int number, int max, int min)
    {
        DayNumber = number;
        MaxTemp = max;
        MinTemp = min;
    }
}