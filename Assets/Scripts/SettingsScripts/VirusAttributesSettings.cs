using UnityEngine;

/// <summary>
/// ����������� ��������� ��������� ������, �� ���������� �� ���� ����.
/// </summary>
[System.Serializable]
public struct VirusAttributesSettings
{
    public AttributeRange ColdResistanceRange; // ������������� ������
    public AttributeRange HeatResistanceRange;// ������������� ����
    public AttributeRange MaxHealthRange; // ������������ ��������
    public AttributeRange HealthRegenerationRange; //����������� �����������
    public AttributeRange HungerResistanceRange; //������������� ������
    public AttributeRange ThirstResistanceRange; // ������������� ������
    public AttributeRange AgeImpactRange; // ������� �������� �� ���� ��
    public AttributeRange MovementSpeedRange; // ��������
    public AttributeRange ComfortTemperatureRange; // ���������� �����������

    public int DefaultHungerResistanceScale;  // �� ������� ������ ������������� ������
    public int DefaultThirstResistanceScale; // �� ������� ������ ������������� �����
    public int DefaultMaxHealthScale; // �� ������� ������ �������� ������������
    public float DefaultMoveSpeedScale; // �� ������� ������ �������� ������������


    public int DefaultMinAttribute; // ����������� ���������� ����������
    public int DefaultMaxAttribute; // ������������ ���������� ����������


}
