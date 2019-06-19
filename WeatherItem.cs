using System;

namespace Lesson7
{
    // Погода
    class WeatherItem
    {
        // Поля
        // дата
        public DateTime date;
        // температура минимальная
        public sbyte mintemp;
        // температура максимальная
        public sbyte maxtemp;
        // облачность
        public Overcast overcast;
        // осадки
        public Precipitation precipitation;
        // влажность
        byte humidity;
        // сила ветра
        public ushort windForce;
        // направление ветра
        public WindDirection windDirection;
        // фаза луны
        public MoonPhase moonPhase;

        // Свойства
        public byte Humidity { get => humidity; set => humidity = (byte)(value > 100 ? 100 : value); }

        // Конструктора
        public WeatherItem() : this(DateTime.Today)
        {
        }

        public WeatherItem(DateTime date)
        {
            this.date = date;
        }

        public WeatherItem(DateTime date, sbyte mintemp, sbyte maxtemp, Overcast overcast, Precipitation precipitation, ushort windForce, WindDirection windDirection, MoonPhase moonPhase, byte humidity) : this(date)
        {
            this.mintemp = mintemp;
            this.maxtemp = maxtemp;
            this.overcast = overcast;
            this.precipitation = precipitation;
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

            return $"Дата              -> {date.ToShortDateString()}\n" +
                   $"min Т, C          -> {mintemp.ToString()}\n" +
                   $"max Т, C          -> {maxtemp.ToString()}\n" +
                   $"Облачность        -> {overcastList[(int)overcast]}\n" +
                   $"Осадки            -> {precipitationList[(int)precipitation]}\n" +
                   $"Влажность, %      -> {Humidity.ToString()}\n" +
                   $"Сила ветра, м/с   -> {windForce.ToString()}\n" +
                   $"Направление ветра -> {windDirectionList[(int)windDirection]}\n" +
                   $"Фаза луны         -> {moonPhaseList[(int)moonPhase]}\n";
        }
    }

}
