using UnityEngine;

/// <summary>
/// ����� ��������� ���� - ��������� ����
/// </summary>

public class WaterSource : MonoBehaviour
{
    public int MaxWater; // ������������ ���-�� ����
    public int CurrentWater; // ������� ���-�� ����
    public int RefillAmount; // ���-�� ����, ������� ��������� �� RefillTime
    public float RefillTime; // �����, �� ������� ��������� RefillAmount ���-�� ����

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


}
