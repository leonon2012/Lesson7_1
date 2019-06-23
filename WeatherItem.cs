using System;

namespace Lesson7
{
    // Погода
    class WeatherItem
    {
        // Поля
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

        // Свойства
        public byte Humidity { get => humidity; set => humidity = (byte)(value > 100 ? 100 : value); }
        public DateTime Date { get => date; set => date = value; }
        public sbyte Mintemp { get => mintemp; set => mintemp = value; }
        public sbyte Maxtemp { get => maxtemp; set => maxtemp = value; }
        public Overcast Overcast { get => overcast; set => overcast = value; }
        public Precipitation Precipitation { get => precipitation; set => precipitation = value; }
        public ushort WindForce { get => windForce; set => windForce = value; }
        public WindDirection WindDirection { get => windDirection; set => windDirection = value; }
        public MoonPhase MoonPhase { get => moonPhase; set => moonPhase = value; }

        // Конструктора
        public WeatherItem() : this(DateTime.Today)
        {
        }

        public WeatherItem(DateTime date)
        {
            this.Date = date;
        }

        public WeatherItem(DateTime date, sbyte mintemp, sbyte maxtemp, Overcast overcast, Precipitation precipitation, ushort windForce, WindDirection windDirection, MoonPhase moonPhase, byte humidity) : this(date)
        {
            this.Mintemp = mintemp;
            this.Maxtemp = maxtemp;
            this.Overcast = overcast;
            this.Precipitation = precipitation;
            this.windForce = windForce;
            this.windDirection = windDirection;
            this.moonPhase = moonPhase;
            Humidity = humidity;
        }


        // Текстовое представление
        public override string ToString()
        {
            string[] overcastList = { "Не определено", "Ясно", "Малооблачно", "Облачно", "Грозовые тучи" };
            string[] precipitationList = { "Не определено", "Дождь", "Снег", "Дождь со снегом", "Град", "Снежная крупа", "Роса", "Иней", "Изморозь", "Гололед", "Ледяные иглы" };
            string[] windDirectionList = { "Не определено", "Север", "Северо-восток", "Восток", "Юго-восток", "Юг", "Юго-запад", "Запад", "Северо-запад" };
            string[] moonPhaseList = { "Не определено", "Новолуние", "Растущая", "Полнолуние", "Убывающая" };

            return $"Дата              -> {Date.ToShortDateString()}\n" +
                   $"min Т, C          -> {Mintemp.ToString()}\n" +
                   $"max Т, C          -> {Maxtemp.ToString()}\n" +
                   $"Облачность        -> {overcastList[(int)Overcast]}\n" +
                   $"Осадки            -> {precipitationList[(int)Precipitation]}\n" +
                   $"Влажность, %      -> {Humidity.ToString()}\n" +
                   $"Сила ветра, м/с   -> {windForce.ToString()}\n" +
                   $"Направление ветра -> {windDirectionList[(int)windDirection]}\n" +
                   $"Фаза луны         -> {moonPhaseList[(int)moonPhase]}\n";
        }
    }

}
