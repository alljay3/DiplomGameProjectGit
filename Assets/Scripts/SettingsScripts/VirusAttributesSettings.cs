using UnityEngine;

/// <summary>
/// Стандартные настройки атрибутов вируса, не изменяются по ходу игры.
/// </summary>
[System.Serializable]
public struct VirusAttributesSettings
{
    public AttributeRange ColdResistanceRange; // Сопротивление Холоду
    public AttributeRange HeatResistanceRange;// Сопротивление Жаре
    public AttributeRange MaxHealthRange; // Максимальное здоровье
    public AttributeRange HealthRegenerationRange; //Максмальная регенерация
    public AttributeRange ReproductionCooldownRange; //Время для следущего размножения
    public AttributeRange HungerResistanceRange; //Сопротивление голоду
    public AttributeRange ThirstResistanceRange; // Сопротивление Жажаде
    public AttributeRange AgeImpactRange; // Влияние возраста на макс хп
    public AttributeRange MovementSpeedRange; // Скорость
    public AttributeRange ComfortTemperatureRange; // Комфортная температура

    public int DefaultMaxHealthScale; // На сколько влияет скорость передвижения
    public float DefaultMoveSpeedScale; // На сколько влияет скорость передвижения


    public int DefaultMinAttribute; // Минимальный показатель аттрибутов
    public int DefaultMaxAttribute; // Максимальный показалеть аттрибутов
}
