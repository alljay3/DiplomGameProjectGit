using UnityEngine;

/// <summary>
/// Класс, отвечающий за все, что проиходит в игровом мире
/// </summary>
public class GameManager : MonoBehaviour
{
    public WorldSettings WSettings; // Настройки мира
    public VirusSettings VSettings; // Настройки вируса
    public VirusStatsSettings VStatsSettings; // Настройки статусов вируса
    public VirusAttributesSettings ASettings; // Настройки атрибутов вируса
    public WorldStats WStats; // Настройки мира

}
