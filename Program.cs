using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherItem W1 = new WeatherItem(DateTime.Today, 10, 15, Overcast.Cloudy, Precipitation.Dew, 3, WindDirection.Northeast, MoonPhase.Falling, 78);

            Console.WriteLine(W1);
        }
    }
}
