using System;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Атрибуты вируса, задают уникальность вирусу, используются в эволюционных алгоритмах в качестве геномов.
/// </summary>

public struct VirusAttrubutes
{
    private int _coldResistance;       // Сопротивление холоду
    private int _heatResistance;       // Сопротивление жаре
    private int _maxHealth;            // Здоровье (общее)
    private int _healthRegeneration;   // Восстановление здоровья
    private int _hungerResistance;     // Сопротивление голоду
    private int _thirstResistance;     // Сопротивление жажде
    private int _ageImpact;            // Влияние возраста
    private int _movementSpeed;        // Скорость перемещения
    private int _comfortTemperature;   // Комфортная температура

    public int ColdResistance
    {
        get => _coldResistance;
        set => _coldResistance = Math.Max(0, value);
    }

    public int HeatResistance
    {
        get => _heatResistance;
        set => _heatResistance = Math.Max(0, value);
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = Math.Max(0, value);
    }

    public int HealthRegeneration
    {
        get => _healthRegeneration;
        set => _healthRegeneration = Math.Max(0, value);
    }

    public int HungerResistance
    {
        get => _hungerResistance;
        set => _hungerResistance = Math.Max(0, value);
    }

    public int ThirstResistance
    {
        get => _thirstResistance;
        set => _thirstResistance = Math.Max(0, value);
    }

    public int AgeImpact
    {
        get => _ageImpact;
        set => _ageImpact = Math.Max(0, value);
    }

    public int MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = Math.Max(0, value);
    }

    public int ComfortTemperature
    {
        get => _comfortTemperature;
        set => _comfortTemperature = value;
    }
}
