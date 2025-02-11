using System.Collections;
using UnityEngine;


/// <summary>
/// Класс куста - источника пищи
/// </summary>
public class BerryBush : MonoBehaviour
{

    public int MaxFood; /// Максимальная еда
    public int CurrentFood; // Текущая еда
    public int RefillAmount; // кол-во еды, которое поступает за RefillTime
    public float RefillTime; // время, за которое поступает RefillAmount кол-во еды


    private SettingsManager _settingsManager;


    public void Start() // Инициализирует начальные значения куста
    {
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        MaxFood = _settingsManager.NBerryBushSettings.MaxFood;
        CurrentFood = _settingsManager.NBerryBushSettings.StartFood;
        if (_settingsManager.NBerryBushSettings.StartFood > MaxFood)
            CurrentFood = MaxFood;
        else
            CurrentFood = _settingsManager.NBerryBushSettings.StartFood;
        RefillAmount = _settingsManager.NBerryBushSettings.DefaultRefillAmount;
        RefillTime = _settingsManager.NBerryBushSettings.DefaultRefillTime;
        StartCoroutine(RefillFoodOverTime());
    }

    public void AddRefillAmout(int addingAmount) // Добавляет или уменьшает количество еды, восстанавливаемое за определённое время
    {
        RefillAmount += addingAmount;
        if (RefillAmount < 0)
            RefillAmount = 0;
    }

    public void AddRefillTime(float addingTime) // Добавляет или уменьшает время восстановления еды (RefillTime).
    {
        RefillTime += addingTime;
        if (RefillTime < 0)
            RefillTime = 0;
    }

    public void AddMaxFood(int addingMaxFood) // Добавляет или уменьшает максимальное количество еды (MaxFood).
    {
        MaxFood += addingMaxFood;
        if (MaxFood < 0)
            MaxFood = 0;
    }

    public void DropCurFood() // Устанавливает текущее количество еды в 0.
    {
        CurrentFood = 0;
    }

    public int EatFromBush(int countEat) // Позволяет "съесть" определённое количество еды из куста.
    {
        if (countEat > CurrentFood)
        {
            countEat = CurrentFood;
        }
        CurrentFood -= countEat;
        return countEat;
    }

    IEnumerator RefillFoodOverTime() // Восстанавливает еду в кусте с течением времени.
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

    private void OnMouseDown()
    {
        GameObject.FindFirstObjectByType<Interface>().SetSelectedObject(gameObject);
    }
}
