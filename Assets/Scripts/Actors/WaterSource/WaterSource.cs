using System.Collections;
using UnityEngine;

/// <summary>
///  ласс хранилища воды - источника воды
/// </summary>

public class WaterSource : MonoBehaviour
{
    public int MaxWater; // ћаксимальное кол-во воды
    public int CurrentWater; // “екущее кол-во воды
    public int RefillAmount; // кол-во воды, которое поступает за RefillTime
    public float RefillTime; // врем€, за которое поступает RefillAmount кол-во воды

    private SettingsManager _settingsManager;

    public void Start()
    {
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        MaxWater = _settingsManager.NWaterSourceSettings.MaxWater;
        if (_settingsManager.NWaterSourceSettings.StartWater > MaxWater)
            CurrentWater = MaxWater;
        else
            CurrentWater = _settingsManager.NWaterSourceSettings.StartWater;
        RefillAmount = _settingsManager.NWaterSourceSettings.DefaultRefillAmount;
        RefillTime = _settingsManager.NWaterSourceSettings.DefaultRefillTime;
        StartCoroutine(RefillWaterOverTime());
    }


    public void AddRefillAmout(int addingAmount) 
    {
        RefillAmount += addingAmount;
        if (RefillAmount < 0)
            RefillAmount = 0;
    }

    public void AddRefillTime(float addingTime)
    {
        RefillTime += addingTime;
        if (RefillTime < 0)
            RefillTime = 0;
    }

    public void AddMaxWater(int addingMaxWater)
    {
        MaxWater += addingMaxWater;
        if (MaxWater < 0)
            MaxWater = 0;
    }

    public void DropCurWater()
    {
        CurrentWater = 0;
    }

    public int DrinkFromSource(int countDrink)
    {
        if (countDrink > CurrentWater)
        {
            countDrink = CurrentWater;
        }
        CurrentWater -= countDrink;
        return countDrink;
    }


    IEnumerator RefillWaterOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(RefillTime);
            CurrentWater += RefillAmount;
            if (CurrentWater > MaxWater)
            {
                CurrentWater = MaxWater;
            }
        }
    }

    private void OnMouseDown()
    {
        GameObject.FindFirstObjectByType<Interface>().SetSelectedObject(gameObject);
    }


}
