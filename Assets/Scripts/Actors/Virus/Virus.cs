using UnityEngine;

/// <summary>
/// Класс вируса
/// </summary>

public class  Virus : MonoBehaviour
{
    public VirusStats Stats; // Статусы вируса
    public VirusAttrubutes Attrubutes; // Атрибуты вируса

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        Attrubutes.ColdResistance = Random.Range(_gameManager.GVirusAttributesSettings.ColdResistanceRange.Min, _gameManager.GVirusAttributesSettings.ColdResistanceRange.Max);
        Attrubutes.HeatResistance = Random.Range(_gameManager.GVirusAttributesSettings.HeatResistanceRange.Min, _gameManager.GVirusAttributesSettings.HeatResistanceRange.Max);
        Attrubutes.MaxHealth = Random.Range(_gameManager.GVirusAttributesSettings.MaxHealthRange.Min, _gameManager.GVirusAttributesSettings.MaxHealthRange.Max);
        Attrubutes.HealthRegeneration = Random.Range(_gameManager.GVirusAttributesSettings.HealthRegenerationRange.Min, _gameManager.GVirusAttributesSettings.HealthRegenerationRange.Max);
        Attrubutes.ReproductionCooldown = Random.Range(_gameManager.GVirusAttributesSettings.ReproductionCooldownRange.Min, _gameManager.GVirusAttributesSettings.ReproductionCooldownRange.Max);
        Attrubutes.HungerResistance = Random.Range(_gameManager.GVirusAttributesSettings.HungerResistanceRange.Min, _gameManager.GVirusAttributesSettings.HungerResistanceRange.Max);
        Attrubutes.ThirstResistance = Random.Range(_gameManager.GVirusAttributesSettings.ThirstResistanceRange.Min, _gameManager.GVirusAttributesSettings.ThirstResistanceRange.Max);
        Attrubutes.AgeImpact = Random.Range(_gameManager.GVirusAttributesSettings.AgeImpactRange.Min, _gameManager.GVirusAttributesSettings.AgeImpactRange.Max);
        Attrubutes.MovementSpeed = Random.Range(_gameManager.GVirusAttributesSettings.MovementSpeedRange.Min, _gameManager.GVirusAttributesSettings.MovementSpeedRange.Max);
        Attrubutes.ComfortTemperature = Random.Range(_gameManager.GVirusAttributesSettings.ComfortTemperatureRange.Min, _gameManager.GVirusAttributesSettings.ComfortTemperatureRange.Max);
    }
}
