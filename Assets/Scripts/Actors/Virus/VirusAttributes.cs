using UnityEngine;

[System.Serializable]
/// <summary>
/// �������� ������, ������ ������������ ������, ������������ � ������������ ���������� � �������� �������.
/// </summary>

public struct VirusAttrubutes
{
    public int ColdResistance;       // ������������� ������
    public int HeatResistance;       // ������������� ����
    public int MaxHealth;            // �������� (�����)
    public int HealthRegeneration;   // �������������� ��������
    public int HungerResistance;     // ������������� ������
    public int ThirstResistance;     // ������������� �����
    public int AgeImpact;            // ������� ��������
    public int MovementSpeed;        // �������� �����������
    public int ComfortTemperature;   // ���������� �����������
}
