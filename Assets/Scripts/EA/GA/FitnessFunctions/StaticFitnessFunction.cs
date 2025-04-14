using UnityEngine;

public class StaticFitnessFunction : IFitnessFunction
{
    public float ColdResistanceFactor = 1;       // ������������� ������
    public float HeatResistanceFactor = 1;       // ������������� ����
    public float MaxHealthFactor = 1;            // �������� (�����)
    public float HealthRegenerationFactor = 1;   // �������������� ��������
    public float HungerResistanceFactor = 1;     // ������������� ������
    public float ThirstResistanceFactor = 1;     // ������������� �����
    public float AgeImpactFactor = 1;            // ������� ��������
    public float MovementSpeedFactor = 1;        // �������� �����������
    public float ComfortTemperatureFactor = 1;   // ���������� �����������
    public override float UseFitnessFunction(Virus virus)
    {
        VirusAttrubutes virusAttrubute = virus.GetComponent<Virus>().Attributes;
        return
            ColdResistanceFactor * virusAttrubute.ColdResistance +
            HeatResistanceFactor * virusAttrubute.HeatResistance +
            MaxHealthFactor * virusAttrubute.MaxHealth +
            HealthRegenerationFactor * virusAttrubute.HealthRegeneration +
            HungerResistanceFactor * virusAttrubute.HungerResistance +
            ThirstResistanceFactor * virusAttrubute.ThirstResistance +
            AgeImpactFactor * virusAttrubute.AgeImpact +
            MovementSpeedFactor * virusAttrubute.MovementSpeed;
    }
}
