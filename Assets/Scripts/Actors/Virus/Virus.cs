using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public enum VirusTask
{
    Thirst,    // Жажда
    Hunger,      // Голод
    Hold,     // Ждать
    Eat, // Ест
    Drink, // Пьет
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
    private float _lastDrinkTime = 0f;
    private float _lastEatTime = 0f;

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
            Task = VirusTask.Hunger;
        if (Stats.CurrentThirst <= _settingsManager.NVirusSettings.DrinkThreshold)
            Task = VirusTask.Thirst;
    }


    public void RelizeTask() // Реализовать задачу
    {
        if (Task == VirusTask.Thirst)
            GoDrink();
        if (Task == VirusTask.Hunger)
            GoEat();
        if (Task == VirusTask.Reproduce)
            GoReproduce();
    }

    private void GoDrink()
    {
        WaterSource[] WaterSources = GameObject.FindObjectsByType<WaterSource>(FindObjectsSortMode.None);
        float MinDistance = float.MaxValue;
        WaterSource NearestWaterSource = null;
        foreach (WaterSource source in WaterSources) 
        { 
            if (Vector3.Distance(source.transform.position, transform.position) < MinDistance && _settingsManager.NVirusSettings.MinWaterToDrink < source.CurrentWater)
            {
                NearestWaterSource = source;
                MinDistance = Vector3.Distance(source.transform.position, transform.position);
            }
        }
        if (NearestWaterSource != null)
        {
            MoveTowards(NearestWaterSource.transform.position);
        }

    }

    private void GoEat()
    {
        BerryBush[] BerryBushes = GameObject.FindObjectsByType<BerryBush>(FindObjectsSortMode.None);
        float MinDistance = float.MaxValue;
        BerryBush NearestBerryBush = null;
        foreach (BerryBush bush in BerryBushes)
        {
            if (Vector3.Distance(bush.transform.position, transform.position) < MinDistance && _settingsManager.NVirusSettings.MinFoodToEat < bush.CurrentFood)
            {
                NearestBerryBush = bush;
                MinDistance = Vector3.Distance(bush.transform.position, transform.position);
            }
        }
        if (NearestBerryBush != null)
        {
            MoveTowards(NearestBerryBush.transform.position);
        }
    }

    private void GoReproduce()
    {


    }

    void MoveTowards(Vector3 targetPosition)
    {
        // Плавное перемещение к целевой позиции
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Stats.CurrentMovementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {       
        if ((Task == VirusTask.Thirst || Task == VirusTask.Drink) && collision.gameObject.TryGetComponent<WaterSource>(out WaterSource source))
        {
            Task = VirusTask.Drink;
            if (Time.time - _lastDrinkTime >= _settingsManager.NVirusSettings.DrinkDepletionSpeed)
            {
                int countDrink = source.DrinkFromSource(_settingsManager.NVirusSettings.DrinkDepletionAmount);
                if (countDrink == 0)
                {
                    Task = VirusTask.Hold;
                }
                Stats.CurrentThirst += countDrink;
                _lastDrinkTime = Time.time; 

                if (Stats.CurrentThirst >= Stats.MaxThirst)
                {
                    Task = VirusTask.Hold;
                }
            }
        }

        if ((Task == VirusTask.Hunger || Task == VirusTask.Eat) && collision.gameObject.TryGetComponent<BerryBush>(out BerryBush bush))
        {
            Task = VirusTask.Eat;
            if (Time.time - _lastEatTime >= _settingsManager.NVirusSettings.EatDepletionSpeed)
            {
                int countEat = bush.EatFromBush(_settingsManager.NVirusSettings.EatDepletionAmount);
                if (countEat == 0)
                {
                    Task = VirusTask.Hold;
                }
                Stats.CurrentHunger += countEat;
                _lastEatTime = Time.time;

                if (Stats.CurrentHunger >= Stats.MaxHunger)
                {
                    Task = VirusTask.Hold;
                }
            }
        }
    }

    public void FirstStart() // Вызывается, если особи первые в игровом мире
    {
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        Attrubutes.ColdResistance = Random.Range(_settingsManager.NVirusAttributesSettings.ColdResistanceRange.Min, _settingsManager.NVirusAttributesSettings.ColdResistanceRange.Max);
        Attrubutes.HeatResistance = Random.Range(_settingsManager.NVirusAttributesSettings.HeatResistanceRange.Min, _settingsManager.NVirusAttributesSettings.HeatResistanceRange.Max);
        Attrubutes.MaxHealth = Random.Range(_settingsManager.NVirusAttributesSettings.MaxHealthRange.Min, _settingsManager.NVirusAttributesSettings.MaxHealthRange.Max);
        Attrubutes.HealthRegeneration = Random.Range(_settingsManager.NVirusAttributesSettings.HealthRegenerationRange.Min, _settingsManager.NVirusAttributesSettings.HealthRegenerationRange.Max);       
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
        Stats.CurrentHunger = _settingsManager.NVirusStatsSettings.DefaultStartHunger;
        Stats.CurrentThirst = _settingsManager.NVirusStatsSettings.DefaultStartThirst;
        Stats.CurrentAge = _settingsManager.NVirusStatsSettings.DefaultAge;
        Stats.CurrentMaxHealth = _settingsManager.NVirusStatsSettings.DefaultVirusHp + Attrubutes.MaxHealth * _settingsManager.NVirusAttributesSettings.DefaultMaxHealthScale;
        Stats.CurrentHealth = Stats.CurrentMaxHealth;
        Stats.CurrentColdResistance = Attrubutes.ColdResistance;
        Stats.CurrentHeatResistance = Attrubutes.HeatResistance;
        Stats.CurrentHealthRegeneration = Attrubutes.HealthRegeneration;
        Stats.CurrentHungerResistance = Attrubutes.HungerResistance;
        Stats.CurrentThirstResistance = Attrubutes.ThirstResistance;
        Stats.CurrentAgeImpact = Attrubutes.AgeImpact;
        Stats.CurrentMovementSpeed = _settingsManager.NVirusStatsSettings.DefaultMoveSpeed + Attrubutes.MovementSpeed * _settingsManager.NVirusAttributesSettings.DefaultMoveSpeedScale;
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

    private void OnMouseDown()
    {
        GameObject.FindFirstObjectByType<Interface>().SetSelectedObject(gameObject);
    }

}
