using UnityEngine;

/// <summary>
/// ����������� ��������� �������� ������, �� ���������� �� ���� ����.
/// </summary>
[System.Serializable]
public struct VirusStatsSettings
{
    public int DefaultMaxHunger; // ������������ �����
    public int DefaultMaxThirst; // ������������ �����
    public int DefaultStartHunger; // ��������� ������������ �����
    public int DefaultStartThirst; // ��������� ������������ �����
    public int DefaultVirusHp; // ����������� �������� ��� ����� ������
    public float DefaultMoveSpeed; // ����������� �������� ��� �������� ������
    public int DefaultAge; // �������, � ������� �������� �����

}
