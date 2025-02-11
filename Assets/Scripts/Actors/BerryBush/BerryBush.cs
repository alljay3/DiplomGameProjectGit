using System.Collections;
using UnityEngine;


/// <summary>
/// ����� ����� - ��������� ����
/// </summary>
public class BerryBush : MonoBehaviour
{

    public int MaxFood; /// ������������ ���
    public int CurrentFood; // ������� ���
    public int RefillAmount; // ���-�� ���, ������� ��������� �� RefillTime
    public float RefillTime; // �����, �� ������� ��������� RefillAmount ���-�� ���


    private SettingsManager _settingsManager;


    public void Start() // �������������� ��������� �������� �����
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

    public void AddRefillAmout(int addingAmount) // ��������� ��� ��������� ���������� ���, ����������������� �� ����������� �����
    {
        RefillAmount += addingAmount;
        if (RefillAmount < 0)
            RefillAmount = 0;
    }

    public void AddRefillTime(float addingTime) // ��������� ��� ��������� ����� �������������� ��� (RefillTime).
    {
        RefillTime += addingTime;
        if (RefillTime < 0)
            RefillTime = 0;
    }

    public void AddMaxFood(int addingMaxFood) // ��������� ��� ��������� ������������ ���������� ��� (MaxFood).
    {
        MaxFood += addingMaxFood;
        if (MaxFood < 0)
            MaxFood = 0;
    }

    public void DropCurFood() // ������������� ������� ���������� ��� � 0.
    {
        CurrentFood = 0;
    }

    public int EatFromBush(int countEat) // ��������� "������" ����������� ���������� ��� �� �����.
    {
        if (countEat > CurrentFood)
        {
            countEat = CurrentFood;
        }
        CurrentFood -= countEat;
        return countEat;
    }

    IEnumerator RefillFoodOverTime() // ��������������� ��� � ����� � �������� �������.
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
