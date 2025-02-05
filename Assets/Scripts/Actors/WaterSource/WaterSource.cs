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
    }
}
