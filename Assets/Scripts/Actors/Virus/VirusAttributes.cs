using UnityEngine;


/// <summary>
/// Атрибуты вируса, задают уникальность вирусу, используются в эволюционных алгоритмах в качестве геномов.
/// </summary>

public struct VirusAttrubutes
{
    public int ColdResistance;       // Сопротивление холоду
    public int HeatResistance;       // Сопротивление жаре
    public int MaxHealth;            // Здоровье (общее)
    public int HealthRegeneration;   // Восстановление здоровья
    public int ReproductionCooldown; // Способность к размножению
    public int HungerResistance;     // Сопротивление голоду
    public int ThirstResistance;     // Сопротивление жажде
    public int AgeImpact;            // Влияние возраста
    public int MovementSpeed;        // Скорость перемещения
    public int ComfortTemperature;   // Комфортная температура
}
