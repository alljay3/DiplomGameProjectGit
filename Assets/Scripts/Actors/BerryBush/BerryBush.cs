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
