using UnityEngine;


/// <summary>
/// Статусы вируса,которые задаются и изменяются по ходу игры.
/// </summary>
public struct VirusStats
{
    public int CurrentHealth; // Текущие жизни
    public int CurrentHunger; // Текущий голод
    public int CurrentThirst; // Текущая жажда
    public int CurrentAge; // Текущий возраст
    public float CurrentMoveSpeed; // Текущая скорость передвижение
}
