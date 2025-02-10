using UnityEngine;

[System.Serializable]
/// <summary>
/// ����������� ��������� ����, �� ���������� �� ���� ����.
/// </summary>
public struct WorldSettings
{
    public int FirstStage; // ����� ������ ������
    public int StartPoints; // ���-�� ����� � ������ ����
    public int VirusCountScore; // ������� ����� ��������� � ����� ������, �� ���-�� ����� �������
    public int TimeUntilNextStage; // ����� �� ��������� ������
    public int FirstTemp; // ��������� �����������
    public int CostUpTemp; // ���� ��������� ����������� � �������
    public int CostDownTemp; // ���� ��������� ����������� � �������
    public int CostSuperUpTemp; // ���� ������� ��������� �����������
    public int CostSuperDownTemp; // ���� ������� ��������� �����������
    public int CostDropFood; // ���� ������ ���
    public int CostDropWater; // ���� ������ ����
    public int UpTempAmount; // ���-�� �������� �����������
    public int UpTempTime; // ����� �������� �����������
    public int DownTempAmount; // ���-�� ��������� �����������
    public int DownTempTime; // ����� ��������� �����������
    public int SuperUpTempAmount; // ���-�� ������� ��������� �����������
    public int SuperDownTempAmount; //���-�� ������� ��������� �����������


}
