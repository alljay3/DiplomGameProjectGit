using UnityEngine;

[System.Serializable]
/// <summary>
/// ������� ������,������� �������� � ���������� �� ���� ����.
/// </summary>
public struct VirusStats
{
    public int MaxHunger; // ������������ �����
    public int MaxThirst; // ������������ �����
    public int CurrentMaxHealth;            // �������� (�����)
    public int CurrentHealth; // ������� �����
    public int CurrentHunger; // ������� �����
    public int CurrentThirst; // ������� �����
    public int CurrentAge; // ������� �������

    public int CurrentColdResistance;       // ������������� ������
    public int CurrentHeatResistance;       // ������������� ����
    public int CurrentHealthRegeneration;   // �������������� ��������
    public int CurrentHungerResistance;     // ������������� ������
    public int CurrentThirstResistance;     // ������������� �����
    public int CurrentAgeImpact;            // ������� ��������
    public float CurrentMovementSpeed;        // �������� �����������
    public int CurrentComfortTemperature;   // ���������� �����������

}
