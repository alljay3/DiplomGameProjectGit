using System;
using UnityEngine;

[System.Serializable]
/// <summary>
/// �������� ������, ������ ������������ ������, ������������ � ������������ ���������� � �������� �������.
/// </summary>

public struct VirusAttrubutes
{
    private int _coldResistance;       // ������������� ������
    private int _heatResistance;       // ������������� ����
    private int _maxHealth;            // �������� (�����)
    private int _healthRegeneration;   // �������������� ��������
    private int _hungerResistance;     // ������������� ������
    private int _thirstResistance;     // ������������� �����
    private int _ageImpact;            // ������� ��������
    private int _movementSpeed;        // �������� �����������
    private int _comfortTemperature;   // ���������� �����������

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
