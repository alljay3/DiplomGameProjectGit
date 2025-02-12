using UnityEngine;

[System.Serializable]
/// <summary>
/// Статусы вируса,которые задаются и изменяются по ходу игры.
/// </summary>
public struct VirusStats
{
    public int MaxHunger; // Максимальный голод
    public int MaxThirst; // Максимальная жажда
    public int CurrentMaxHealth;            // Здоровье (общее)
    public int CurrentHealth; // Текущие жизни
    public int CurrentHunger; // Текущий голод
    public int CurrentThirst; // Текущая жажда
    public int CurrentAge; // Текущий возраст

    public int CurrentColdResistance;       // Сопротивление холоду
    public int CurrentHeatResistance;       // Сопротивление жаре
    public int CurrentHealthRegeneration;   // Восстановление здоровья
    public int CurrentHungerResistance;     // Сопротивление голоду
    public int CurrentThirstResistance;     // Сопротивление жажде
    public int CurrentAgeImpact;            // Влияние возраста
    public float CurrentMovementSpeed;        // Скорость перемещения
    public int CurrentComfortTemperature;   // Комфортная температура

}
