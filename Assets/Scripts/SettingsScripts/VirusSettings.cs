using UnityEngine;

[System.Serializable]
/// <summary>
/// Стандартные настройки вируса, не изменяются по ходу игры.
/// </summary>
public struct VirusSettings
{
    public int DefaultVirusTempDmg; // Стандартный урон от температуры
    public int DefaultVirusHungerDmg; // Стандартный урон от голода
    public int DefaultVirusThirstDmg; // Стандартный урон от жажды
    public int DefaultTimeTakeDmg; // Стандартное время для получение урона
    public float DefaultScaleTempDmg; // Увеличение урона от температуры
    public float DefaultScaleHungerDmg; // Увеличение урона от голода 
    public float DefaultScaleThirstDmg; // Увеличение урона от жажды

    public float HungerDepletionSpeed; // Скорость голодания
    public int HungerDepletionAmount; // Количество голодания

    public float waterDepletionSpeed; // Скрорость уменьшение воды
     
    public int waterDepletionAmount; // Кол-во уменьшение воды


}
