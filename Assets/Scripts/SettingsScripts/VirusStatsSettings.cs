using UnityEngine;

/// <summary>
/// Стандартные настройки статусов вируса, не изменяются по ходу игры.
/// </summary>
[System.Serializable]
public struct VirusStatsSettings
{
    public int MaxHunger; // Максимальный голод
    public int MaxThirst; // Максимальная жажда
}
