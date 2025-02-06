using UnityEngine;

[System.Serializable]
/// <summary>
/// ����������� ��������� ������, �� ���������� �� ���� ����.
/// </summary>
public struct VirusSettings
{
    public int DefaultVirusHp; // ����������� �������� ��� ����� ������
    public float DefaultVirusSpeed; // ����������� �������� ��� �������� ������
    public int DefaultVirusTempDmg; // ����������� ���� �� �����������
    public int DefaultVirusHungerDmg; // ����������� ���� �� ������
    public int DefaultVirusThirstDmg; // ����������� ���� �� �����
    public int DefaultTimeTakeDmg; // ����������� ����� ��� ��������� �����
    public float DefaultScaleDmgTemp;
    public float DefaultScaleHungerDmg;
    public float DefaultScaleThirstDmg;
}
