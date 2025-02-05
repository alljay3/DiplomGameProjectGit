using UnityEngine;


[System.Serializable]
/// <summary>
/// —тандартные настройки водного источника, не измен€ютс€ по ходу игры.
/// </summary>


public struct WaterSourceSettings
{
    public int StartWater; // Ќачальный запас воды
    public int MaxWater; // ћаксимальное кол-во воды
    public int DefaultRefillAmount; // кол-во воды, которое поступает за DefaultRefillTime
    public float DefaultRefillTime; // врем€, за которое поступает DefaultRefillAmount кол-во воды
}
