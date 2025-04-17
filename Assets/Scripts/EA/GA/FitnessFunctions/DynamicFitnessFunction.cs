using UnityEngine;

public class DynamicFitnessFunction : IFitnessFunction
{
    public float ColdResistanceFactor = 1;       // Сопротивление холоду
    public float HeatResistanceFactor = 1;       // Сопротивление жаре
    public float MaxHealthFactor = 1;            // Здоровье (общее)
    public float HealthRegenerationFactor = 1;   // Восстановление здоровья
    public float HungerResistanceFactor = 1;     // Сопротивление голоду
    public float ThirstResistanceFactor = 1;     // Сопротивление жажде
    public float AgeImpactFactor = 1;            // Влияние возраста
    public float MovementSpeedFactor = 1;        // Скорость перемещения
    public float ComfortTemperatureFactor = 1;   // Комфортная температура
    public int MinFood = 25;
    public int MinWater = 110;
    public int StartFitnessPoint = 1000;
    private GameManager _gameManager;
    
    public override float UseFitnessFunction(Virus virus)
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        VirusAttrubutes virusAttrubute = virus.GetComponent<Virus>().Attributes;
        float resualtFitnessFunction = StartFitnessPoint +
            MaxHealthFactor * virusAttrubute.MaxHealth +
            HealthRegenerationFactor * virusAttrubute.HealthRegeneration +
            AgeImpactFactor * virusAttrubute.AgeImpact +
            MovementSpeedFactor * virusAttrubute.MovementSpeed;
        if (_gameManager.GWorldStats.CurTemp > virus.Attributes.ComfortTemperature)
        {
            resualtFitnessFunction += Mathf.Abs(_gameManager.GWorldStats.CurTemp) * HeatResistanceFactor * virus.Attributes.HeatResistance;
        }
        if (_gameManager.GWorldStats.CurTemp < virus.Attributes.ComfortTemperature)
        {
            resualtFitnessFunction += Mathf.Abs(_gameManager.GWorldStats.CurTemp) * ColdResistanceFactor * virus.Attributes.ColdResistance;
        }
        if (_gameManager.AllFood / _gameManager.CountBushes < MinFood)
        {
            resualtFitnessFunction += HungerResistanceFactor * virusAttrubute.HungerResistance;
        }
        if (_gameManager.AllWater / _gameManager.countWaterSources < MinWater)
        {
            resualtFitnessFunction += ThirstResistanceFactor * virusAttrubute.ThirstResistance;
        }
        resualtFitnessFunction -= Mathf.Abs(_gameManager.GWorldStats.CurTemp - virus.Attributes.ComfortTemperature) * ComfortTemperatureFactor;

        if (resualtFitnessFunction < 1)
        {
            resualtFitnessFunction = 1;
        }

        return resualtFitnessFunction;
    }
}
