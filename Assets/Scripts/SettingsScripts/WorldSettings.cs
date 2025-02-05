using UnityEngine;

[System.Serializable]
/// <summary>
/// Стандартные настройки мира, не изменяются по ходу игры.
/// </summary>
public struct WorldSettings
{
    public int VirusCountScore; // Сколько очков поступает в новую стадию, за кол-во живых вирусов
    public float TimeUntilNextStage; // Время до следующей стадии


}
