using UnityEngine;


[System.Serializable]
/// <summary>
/// ����������� ��������� ������� ���������, �� ���������� �� ���� ����.
/// </summary>


public struct WaterSourceSettings
{
    public int StartWater; // ��������� ����� ����
    public int MaxWater; // ������������ ���-�� ����
    public int DefaultRefillAmount; // ���-�� ����, ������� ��������� �� DefaultRefillTime
    public float DefaultRefillTime; // �����, �� ������� ��������� DefaultRefillAmount ���-�� ����
}
