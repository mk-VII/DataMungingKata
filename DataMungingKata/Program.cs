// See https://aka.ms/new-console-template for more information

using DataMungingKata;

static async Task<int> Main()
{
    var reader = new DataReader();

    var x = await reader.GetRelevantWeatherData();

    return 0;
}