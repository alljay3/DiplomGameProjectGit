using UnityEngine;

/// <summary>
/// Стандартные настройки статусов вируса, не изменяются по ходу игры.
/// </summary>
[System.Serializable]
public struct VirusStatsSettings
{
    public int MaxHunger; // Текущий голод
    public int MaxThirst; // Текущая жажда
}
