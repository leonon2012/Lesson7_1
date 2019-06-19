namespace Lesson7
{
    // облачность
    enum Overcast : byte
    {
        // Ясно, Малооблачно, Облачно, Грозовые тучи
        Undefined, Clear, PartlyCloudy, Cloudy, Thunderclouds
    }

    // осадки
    enum Precipitation : byte
    {
        // Не определено (если информация не занесена), Дождь, Снег, Дождь со снегом, Град, Снежная крупа, Роса, Иней, Изморозь, Гололед, Ледяные иглы
        Undefined, Rain, Snow, RainAndSnow, Hail, SnowGrout, Dew, Hoarfrost, Rime, Ice, IceNeedles
    }    

    // направление ветра
    enum WindDirection : byte
    {
        // Направление ветра: Не определено (если информация не занесена), Север, Северо- восток, Восток, Юго-восток, Юг, Юго-запад, Запад, Северо-запад
        Undefined, North, Northeast, East, Southeast, South, Southwest, West, Northwest
    }

    // фаза луны
    enum MoonPhase : byte
    {
        // Фаза луны: Не определено (если информация не занесена), Новолуние, Растущая, Полнолуние, Убывающая
        Undefined, NewMoon, Growing, FullMoon, Falling
    }

}