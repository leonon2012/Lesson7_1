using System;

namespace Lesson7
{
    class WeatherYear
    {
        // Массив дней в году
        WeatherItem[][] days = new WeatherItem[12][];
        // Год
        int year;
        public WeatherItem[][] Days { get => days; set => days = value; }
        public int Year { get => year; set => year = value; }

        public WeatherYear() : this(DateTime.Today.Year)
        {
        }

        public WeatherYear(int year)
        {
            // Сохраняем год
            Year = year;
            // Инициализируем месяцы днями
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new WeatherItem[DateTime.DaysInMonth(year, i + 1)];
            }
        }

        // Колличество дней
        public int DaysCount()
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
            {
                result += days[i].Length;
            }

            return result;
        }

        // Среднегодовая температура (суммы макс и мин темератур за все дни / удвоенное значение дней)
        public int AvgTemp()
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null)
                        result += day.Maxtemp;
                        //result += day.Mintemp + day.Maxtemp;


            return result / DaysCount();
            //return result / (DaysCount() * 2);
        }

        // Среднее кол-во солнчных дней в месяц (считаем, что солнечный день когда ясно)
        public int AvgMonthSunnyDays()
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null && day.Overcast == Overcast.Clear)
                        result++;

            return result / 12;
        }

        // общее количество дней в году с осадками
        public int PrecipitationDaysCount()
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null && (day.Precipitation == Precipitation.Rain | day.Precipitation == Precipitation.RainAndSnow | day.Precipitation == Precipitation.Snow | day.Precipitation == Precipitation.Hail | day.Precipitation == Precipitation.SnowGrout))
                        result++;

            return result;
        }

        //общее количество дней в году со слабым ветром;
        public int WindForceLessDaysCount(int windForce)
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null && day.WindForce <= windForce)
                        result++;

            return result;
        }

        //общее количество дней с температурой выше заданной
        public int TempMoreDaysCount(int temp)
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null && day.Maxtemp > temp)
                        result++;

            return result;
        }

        //общее количество дней с температурой ниже задвнной
        public int TempLessDaysCount(int temp)
        {
            int result = 0;

            for (int i = 0; i < days.Length; i++)
                foreach (WeatherItem day in days[i])
                    if (day != null && day.Maxtemp < temp)
                        result++;

            return result;
        }

        //месяц с самым большим количеством осадков
        public int MonthWithMaxPrecipitation()
        {
            int result = -1;
            int month = -1;
            int count = 0;

            for (int i = 0; i < days.Length; i++)
            {
                // Кол-во дней с осадками
                foreach (WeatherItem day in days[i])
                    if (day != null && (day.Precipitation == Precipitation.Rain | day.Precipitation == Precipitation.RainAndSnow | day.Precipitation == Precipitation.Snow | day.Precipitation == Precipitation.Hail | day.Precipitation == Precipitation.SnowGrout))
                        count++;

                if (count > month)
                {
                    month = count;
                    result = i + 1;
                }

                count = 0;
            }

            return result;
        }

        //самый безветренный месяц (в котором кол-во дней со слабым ветром минимально)
        public int MonthWithMaxDaysLessWindForce(int windForce)
        {
            int result = -1;
            int month = -1;
            int count = 0;

            for (int i = 0; i < days.Length; i++)
            {
                // Кол-во дней c силой ветра менее заданной

                foreach (WeatherItem day in days[i])
                    if (day != null && day.WindForce <= windForce)
                        count++;

                if (count > month)
                {
                    month = count;
                    result = i + 1;
                }

                count = 0;
            }

            return result;
        }

        //установка значений погоды случайным образом
        public void SetRandom(sbyte minT, sbyte maxT, ushort maxWindForce)
        {
            Random rnd = new Random(150);

            // Генерация случайного значения из перечисления
            T RandomEnum<T>()
            {
                Type type = typeof(T);
                Array values = Enum.GetValues(type);
                lock (rnd)
                {
                    object value = values.GetValue(rnd.Next(1, values.Length));
                    return (T)Convert.ChangeType(value, type);
                }
            }

            // дата
            DateTime date;
            // температура минимальная
            sbyte mintemp;
            // температура максимальная
            sbyte maxtemp;
            // облачность
            Overcast overcast;
            // осадки
            Precipitation precipitation;
            // влажность
            byte humidity;
            // сила ветра
            ushort windForce;
            // направление ветра
            WindDirection windDirection;
            // фаза луны
            MoonPhase moonPhase;

            for (int i = 0; i < days.Length; i++)
            {
                for (int y = 0; y < days[i].Length; y++)
                {
                    // дата
                    date = new DateTime(this.year, i + 1, y + 1);
                    // температура минимальная
                    mintemp = (sbyte)rnd.Next(minT, maxT);
                    // температура максимальная
                    maxtemp = (sbyte)rnd.Next(mintemp, maxT);
                    // облачность
                    overcast = RandomEnum<Overcast>();
                    // осадки
                    precipitation = RandomEnum<Precipitation>();
                    // влажность
                    humidity = (byte)rnd.Next(0, 100);
                    // сила ветра
                    windForce = (ushort)rnd.Next(0, maxWindForce);
                    // направление ветра
                    windDirection = RandomEnum<WindDirection>();
                    // фаза луны
                    moonPhase = RandomEnum<MoonPhase>();

                    days[i][y] = new WeatherItem(date, mintemp, maxtemp, overcast, precipitation, windForce, windDirection, moonPhase, humidity);
                }
            }
        }
    }
}
