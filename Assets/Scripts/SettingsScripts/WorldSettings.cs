using UnityEngine;

[System.Serializable]
/// <summary>
/// Стандартные настройки мира, не изменяются по ходу игры.
/// </summary>
public struct WorldSettings
{
    public int FirstStage; // Номер первой стадии
    public int StartPoints; // Кол-во очков в начале игры
    public int VirusCountScore; // Сколько очков поступает в новую стадию, за кол-во живых вирусов
    public int TimeUntilNextStage; // Время до следующей стадии


}
