using UnityEngine;

/// <summary>
/// Стандартные настройки статусов вируса, не изменяются по ходу игры.
/// </summary>
[System.Serializable]
public struct VirusStatsSettings
{
    public int DefaultMaxHunger; // Максимальный голод
    public int DefaultMaxThirst; // Максимальная жажда
    public int DefaultVirusHp; // Стандартное значение для жизни вируса
    public float DefaultMoveSpeed; // Стандартное значение для скорости вируса
    public int DefaultAge; // Возраст, с которым начинает вирус

}
