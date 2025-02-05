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

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        MaxWater = _gameManager.GWaterSourceSettings.MaxWater;
        if (_gameManager.GWaterSourceSettings.StartWater > MaxWater)
            CurrentWater = MaxWater;
        else
            CurrentWater = _gameManager.GWaterSourceSettings.StartWater;
        RefillAmount = _gameManager.GWaterSourceSettings.DefaultRefillAmount;
        RefillTime = _gameManager.GWaterSourceSettings.DefaultRefillTime;
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

    public int DrinkFromBush(int countDrink)
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


}
