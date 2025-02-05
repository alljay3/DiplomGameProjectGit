using UnityEngine;
[System.Serializable]

/// <summary>
/// ����������� ��������� ������ � ����, �� ���������� �� ���� ����.
/// </summary>

public struct BerryBushSettings
{
    public int StartFood; // ��������� ���-�� ���
    public int MaxFood; // ������������ ���-�� ���
    public int DefaultRefillAmount; // ���-�� ���, ������� ��������� �� DefaultRefillTime
    public float DefaultRefillTime; // �����, �� ������� ��������� DefaultRefillAmount ���-�� ���
}
