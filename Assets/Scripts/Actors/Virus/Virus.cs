using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public enum VirusTask
{
    Drink,    // Пить
    Eat,      // Есть
    Hold,     // Ждать
    Reproduce // Размножаться
}

/// <summary>
/// Класс вируса
/// </summary>

public class  Virus : MonoBehaviour
{
    public VirusStats Stats; // Статусы вируса
    public VirusAttrubutes Attrubutes; // Атрибуты вируса

    public VirusTask Task;

    private SettingsManager _settingsManager;

    public void Start()
    {
        FirstStart(); // Нужно вызывать только если особь из первого поколения
        InitStats();
        StartCoroutine(ChangeHunger());
        StartCoroutine(ChangeThirst());
        Task = VirusTask.Hold;
    } 

    public void FixedUpdate()
    {
        ChooseTask();
        RelizeTask();
    }

    public void ChooseTask() // Выбрать задачу вируса
    {
        if (Task != VirusTask.Hold)
            return;

        if (Stats.CurrentHunger <= _settingsManager.NVirusSettings.EatThreshold)
            Task = VirusTask.Eat;
        if (Stats.CurrentThirst <= _settingsManager.NVirusSettings.DrinkThreshold)
            Task = VirusTask.Drink;
    }


    public void RelizeTask() // Реализовать задачу
    {
        if (Task == VirusTask.Drink)
            Drink();
        if (Task == VirusTask.Eat)
            Eat();
        if (Task == VirusTask.Reproduce)
            Reproduce();
    }

    private void Drink()
    {

    }

    private void Eat()
    {

    }

    private void Reproduce()
    {

    }

    public void FirstStart() // Вызывается, если особи первые в игровом мире
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

    } // Получить урон

    public void InitStats()// Инициализация статов
    {
        Stats.MaxHunger = _settingsManager.NVirusStatsSettings.DefaultMaxHunger;
        Stats.MaxThirst = _settingsManager.NVirusStatsSettings.DefaultMaxThirst;
        Stats.CurrentHunger = Stats.MaxHunger;
        Stats.CurrentThirst = Stats.MaxThirst;
        Stats.CurrentAge = _settingsManager.NVirusStatsSettings.DefaultAge;
        Stats.CurrentMaxHealth = _settingsManager.NVirusStatsSettings.DefaultVirusHp + Attrubutes.MaxHealth * _settingsManager.NVirusAttributesSettings.DefaultMaxHealthScale;
        Stats.CurrentHealth = Stats.CurrentMaxHealth;
        Stats.CurrentColdResistance = Attrubutes.ColdResistance;
        Stats.CurrentHeatResistance = Attrubutes.HeatResistance;
        Stats.CurrentHealthRegeneration = Attrubutes.HealthRegeneration;
        Stats.CurrentReproductionCooldown = Attrubutes.ReproductionCooldown;
        Stats.CurrentHungerResistance = Attrubutes.HungerResistance;
        Stats.CurrentThirstResistance = Attrubutes.ThirstResistance;
        Stats.CurrentAgeImpact = Attrubutes.AgeImpact;
        Stats.CurrentMovementSpeed = Attrubutes.MovementSpeed * _settingsManager.NVirusAttributesSettings.DefaultMoveSpeedScale * _settingsManager.NVirusStatsSettings.DefaultMoveSpeed;
        Stats.CurrentComfortTemperature = Attrubutes.ComfortTemperature;

        for (int i = 0; i < Stats.CurrentAge;  i++)
            ChangeMaxHealth(); // *** Меняется максимальные жизни
    }

    private void ChangeMaxHealth()
    {
        Stats.CurrentMaxHealth -= (_settingsManager.NVirusAttributesSettings.DefaultMaxAttribute - Attrubutes.AgeImpact);
    } // Поменять максимальное hp

    public void NextStage()
    {
        Stats.CurrentAge += 1;
        ChangeMaxHealth();
    } // Новая стадия

    IEnumerator ChangeHunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(_settingsManager.NVirusSettings.HungerDepletionSpeed);
            if (Stats.CurrentHunger > 0)
                Stats.CurrentHunger -= _settingsManager.NVirusSettings.HungerDepletionAmount;
            if (Stats.CurrentHunger < 0)
                Stats.CurrentHunger = 0;
        }
    } // Изменение голода

    IEnumerator ChangeThirst()
    {
        while (true)
        {
            yield return new WaitForSeconds(_settingsManager.NVirusSettings.waterDepletionSpeed);
            if (Stats.CurrentThirst > 0)
                Stats.CurrentThirst -= _settingsManager.NVirusSettings.waterDepletionAmount;
            if (Stats.CurrentThirst < 0)
                Stats.CurrentThirst = 0;
        }
    } // изменение жажды



}
