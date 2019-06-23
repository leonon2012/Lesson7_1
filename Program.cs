using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherItem W1 = new WeatherItem(DateTime.Today, 10, 15, Overcast.Cloudy, Precipitation.Dew, 3, WindDirection.Northeast, MoonPhase.Falling, 78);

            Console.WriteLine(W1);

            WeatherYear Y1 = new WeatherYear(2018);
            Y1.SetRandom(-30, 35, 25);

            Console.WriteLine($"Кол-во дней в году : {Y1.DaysCount()}");
            Console.WriteLine($"Среднегодовая температура : {Y1.AvgTemp()}");
            Console.WriteLine($"Среднее количество солнечных дней в месяц : {Y1.AvgMonthSunnyDays()}");
            Console.WriteLine($"общее количество дней в году с осадками : {Y1.PrecipitationDaysCount()}");
            Console.WriteLine($"общее количество дней в году со слабым ветром : {Y1.WindForceLessDaysCount(5)}");
            Console.WriteLine($"общее количество дней с температурой выше среднегодовой температуры : {Y1.TempMoreDaysCount(Y1.AvgTemp())}");
            Console.WriteLine($"общее количество дней с температурой ниже среднегодовой температуры : {Y1.TempLessDaysCount(Y1.AvgTemp())}");
            Console.WriteLine($"месяц с самым большим количеством осадков : {Y1.MonthWithMaxPrecipitation()}");
            Console.WriteLine($"самый безветренный месяц(в котором кол - во дней со слабым ветром максимально) : {Y1.MonthWithMaxDaysLessWindForce(5)}");
        }
    }
}
