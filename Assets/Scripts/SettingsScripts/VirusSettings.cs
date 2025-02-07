using UnityEngine;

[System.Serializable]
/// <summary>
/// ����������� ��������� ������, �� ���������� �� ���� ����.
/// </summary>
public struct VirusSettings
{
    public int DefaultVirusTempDmg; // ����������� ���� �� �����������
    public int DefaultVirusHungerDmg; // ����������� ���� �� ������
    public int DefaultVirusThirstDmg; // ����������� ���� �� �����
    public int DefaultTimeTakeDmg; // ����������� ����� ��� ��������� �����
    public float DefaultScaleTempDmg; // ���������� ����� �� �����������


    public float HungerDepletionSpeed; // �������� ���������
    public int HungerDepletionAmount; // ���������� ���������
    public float EatDepletionSpeed; // �������� � ������� �������� �����
    public int EatDepletionAmount; // ���-�� � ������� �������� �����
    public int EatThreshold; //  ��������� �������� � ���������, ��� ������� ����� ������.


    public float waterDepletionSpeed; // ��������� ���������� ����    
    public int waterDepletionAmount; // ���-�� ���������� ����
    public float DrinkDepletionSpeed; // �������� �����
    public int DrinkDepletionAmount; // ���-�� �����
    public int DrinkThreshold; // ��������� �������� � ���������, ��� ������� ����� ������.


}
