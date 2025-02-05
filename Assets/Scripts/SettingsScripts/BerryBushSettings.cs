using UnityEngine;
[System.Serializable]

/// <summary>
/// —тандартные настройки кустов с едой, не измен€ютс€ по ходу игры.
/// </summary>

public struct BerryBushSettings
{
    public int StartFood; // Ќачальное кол-во еды
    public int MaxFood; // ћаксимальное кол-во еды
    public int DefaultRefillAmount; // кол-во еды, которое поступает за DefaultRefillTime
    public float DefaultRefillTime; // врем€, за которое поступает DefaultRefillAmount кол-во еды
}
