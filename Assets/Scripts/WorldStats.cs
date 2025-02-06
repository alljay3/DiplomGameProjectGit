using UnityEngine;
[System.Serializable]
/// <summary>
/// Статусы мира, изменяемые по ходу игры.
/// </summary>


public struct WorldStats
{
    public int Points; // Очки игркоа
    public int NumberStage; // Номер стадии
    public int TimeLeft; //Время, отставшееся до новой стадии
    public int TimeToNextStage; // Время до следующей стадии

}
