using UnityEngine;

/// <summary>
/// Класс, отвечающий за все, что проиходит в игровом мире
/// </summary>
public class GameManager : MonoBehaviour
{
    public WorldSettings GWorldSettings; // Настройки мира
    public VirusSettings GVirusSettings; // Настройки вируса
    public VirusStatsSettings GVirusStatsSettings; // Настройки статусов вируса
    public VirusAttributesSettings GVirusAttributesSettings; // Настройки атрибутов вируса
    public BerryBushSettings GBerryBushSettings; // Настройки источников пищи
    public WaterSourceSettings GWaterSourceSettings; // Настройки водных источников
    public WorldStats GWorldStats; // Настройки мира

}
