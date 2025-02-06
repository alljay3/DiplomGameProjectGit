using UnityEngine;

/// <summary>
/// Класс вируса
/// </summary>

public class  Virus : MonoBehaviour
{
    public VirusStats Stats; // Статусы вируса
    public VirusAttrubutes Attrubutes; // Атрибуты вируса

    private SettingsManager _settingsManager;

    public void Start()
    {
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        Attrubutes.ColdResistance = Random.Range(_settingsManager.NVirusAttributesSettings.ColdResistanceRange.Min, _settingsManager.NVirusAttributesSettings.ColdResistanceRange.Max);
        Attrubutes.HeatResistance = Random.Range(_settingsManager.NVirusAttributesSettings.HeatResistanceRange.Min, _settingsManager.NVirusAttributesSettings.HeatResistanceRange.Max);
        Attrubutes.MaxHealth = Random.Range(_settingsManager.NVirusAttributesSettings.MaxHealthRange.Min, _settingsManager.NVirusAttributesSettings.MaxHealthRange.Max);
        Attrubutes.HealthRegeneration = Random.Range(_settingsManager.NVirusAttributesSettings.HealthRegenerationRange.Min, _settingsManager.NVirusAttributesSettings.HealthRegenerationRange.Max);
        Attrubutes.ReproductionCooldown = Random.Range(_settingsManager.NVirusAttributesSettings.ReproductionCooldownRange.Min, _settingsManager.NVirusAttributesSettings.ReproductionCooldownRange.Max);
        Attrubutes.HungerResistance = Random.Range(_settingsManager.NVirusAttributesSettings.HungerResistanceRange.Min, _settingsManager.NVirusAttributesSettings.HungerResistanceRange.Max);
        Attrubutes.ThirstResistance = Random.Range(_settingsManager.NVirusAttributesSettings.ThirstResistanceRange.Min, _settingsManager.NVirusAttributesSettings.ThirstResistanceRange.Max);
        Attrubutes.AgeImpact = Random.Range(_settingsManager.NVirusAttributesSettings.AgeImpactRange.Min, _settingsManager.NVirusAttributesSettings.AgeImpactRange.Max);
        Attrubutes.MovementSpeed = Random.Range(_settingsManager.NVirusAttributesSettings.MovementSpeedRange.Min, _settingsManager.NVirusAttributesSettings.MovementSpeedRange.Max);
        Attrubutes.ComfortTemperature = Random.Range(_settingsManager.NVirusAttributesSettings.ComfortTemperatureRange.Min, _settingsManager.NVirusAttributesSettings.ComfortTemperatureRange.Max);
    }

    public void TakeDmg()
    {

    }
}
