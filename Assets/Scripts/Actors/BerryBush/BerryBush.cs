using System.Collections;
using UnityEngine;


/// <summary>
///  ласс куста - источника пищи
/// </summary>
public class BerryBush : MonoBehaviour
{

    public int MaxFood; /// ћаксимальна€ еда
    public int CurrentFood; // “екуща€ еда
    public int RefillAmount; // кол-во еды, которое поступает за RefillTime
    public float RefillTime; // врем€, за которое поступает RefillAmount кол-во еды


    private GameManager _gameManager;


    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        MaxFood = _gameManager.GBerryBushSettings.MaxFood;
        CurrentFood = _gameManager.GBerryBushSettings.StartFood;
        if (_gameManager.GBerryBushSettings.StartFood > MaxFood)
            CurrentFood = MaxFood;
        else
            CurrentFood = _gameManager.GBerryBushSettings.StartFood;
        RefillAmount = _gameManager.GBerryBushSettings.DefaultRefillAmount;
        RefillTime = _gameManager.GBerryBushSettings.DefaultRefillTime;
        StartCoroutine(RefillFoodOverTime());
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

    public void AddMaxFood(int addingMaxFood)
    {
        MaxFood += addingMaxFood;
        if (MaxFood < 0)
            MaxFood = 0;
    }

    public void DropCurFood()
    {
        CurrentFood = 0;
    }

    public void EatFromBush()
    {

    }

    IEnumerator RefillFoodOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(RefillTime);
            CurrentFood += RefillAmount;
            if (CurrentFood > MaxFood)
            {
                CurrentFood = MaxFood;
            }
        }
    }
}
