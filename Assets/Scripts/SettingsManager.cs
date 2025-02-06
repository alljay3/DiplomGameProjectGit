using UnityEngine;

/// <summary>
/// Класс, отвечающий за все настройки игры
/// </summary>
public class SettingsManager : MonoBehaviour
{
    public WorldSettings NWorldSettings; // Настройки мира
    public VirusSettings NVirusSettings; // Настройки вируса
    public VirusStatsSettings NVirusStatsSettings; // Настройки статусов вируса
    public VirusAttributesSettings NVirusAttributesSettings; // Настройки атрибутов вируса
    public BerryBushSettings NBerryBushSettings; // Настройки источников пищи
    public WaterSourceSettings NWaterSourceSettings; // Настройки водных источников

}
