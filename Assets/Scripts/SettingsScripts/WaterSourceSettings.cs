using UnityEngine;


[System.Serializable]
/// <summary>
/// Стандартные настройки водного источника, не изменяются по ходу игры.
/// </summary>


public struct WaterSourceSettings
{
    public int MaxWater;
    public int RefillAmount;
    public float RefillTime;
}
