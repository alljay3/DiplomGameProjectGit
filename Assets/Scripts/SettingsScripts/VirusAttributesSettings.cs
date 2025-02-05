using UnityEngine;

/// <summary>
/// Стандартные настройки атрибутов вируса, не изменяются по ходу игры.
/// </summary>
[System.Serializable]
public struct VirusAttributesSettings
{
    public AttributeRange ColdResistanceRange;
    public AttributeRange HeatResistanceRange;
    public AttributeRange MaxHealthRange;
    public AttributeRange HealthRegenerationRange;
    public AttributeRange ReproductionCooldownRange;
    public AttributeRange HungerResistanceRange;
    public AttributeRange ThirstResistanceRange;
    public AttributeRange AgeImpactRange;
    public AttributeRange MovementSpeedRange;
    public AttributeRange ComfortTemperatureRange;
}
