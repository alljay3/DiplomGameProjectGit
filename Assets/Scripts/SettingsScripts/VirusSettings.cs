using UnityEngine;

[System.Serializable]
/// <summary>
/// Стандартные настройки вируса, не изменяются по ходу игры.
/// </summary>
public struct VirusSettings
{
    public int DefaultVirusHp; // Стандартное значение для жизни вируса
    public float DefaultVirusSpeed; // Стандартное значение для скорости вируса
    public int DefaultVirusTempDmg; // Стандартный урон от температуры
    public int DefaultVirusHungerDmg; // Стандартный урон от голода
    public int DefaultVirusThirstDmg; // Стандартный урон от жажды
    public int DefaultTimeTakeDmg; // Стандартное время для получение урона
    public float DefaultScaleDmgTemp;
    public float DefaultScaleHungerDmg;
    public float DefaultScaleThirstDmg;
}
