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
    }
}
