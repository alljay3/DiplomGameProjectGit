using UnityEngine;

public class StaticFitnessFunction : IFitnessFunction
{
    public float ColdResistanceFactor = 1;       // Сопротивление холоду
    public float HeatResistanceFactor = 1;       // Сопротивление жаре
    public float MaxHealthFactor = 1;            // Здоровье (общее)
    public float HealthRegenerationFactor = 1;   // Восстановление здоровья
    public float HungerResistanceFactor = 1;     // Сопротивление голоду
    public float ThirstResistanceFactor = 1;     // Сопротивление жажде
    public float AgeImpactFactor = 1;            // Влияние возраста
    public float MovementSpeedFactor = 1;        // Скорость перемещения
    public float ComfortTemperatureFactor = 1;   // Комфортная температура
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
