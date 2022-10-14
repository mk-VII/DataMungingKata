namespace DataMungingKata;

public class WeatherData
{
    public int DayNumber { get; }
    private int _maxTemp;
    private int _minTemp;
    public int Difference { get; }

    public WeatherData(int number, int max, int min)
    {
        DayNumber = number;
        _maxTemp = max;
        _minTemp = min;

        Difference = _maxTemp - _minTemp;
    }
}