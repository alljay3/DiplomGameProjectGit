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
    public float DefaultScaleHungerDmg; // ���������� ����� �� ������ 
    public float DefaultScaleThirstDmg; // ���������� ����� �� �����

    public float HungerDepletionSpeed; // �������� ���������
    public int HungerDepletionAmount; // ���������� ���������

    public float waterDepletionSpeed; // ��������� ���������� ����
     
    public int waterDepletionAmount; // ���-�� ���������� ����


}
