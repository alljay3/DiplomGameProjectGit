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
    public int FirstTemp; // Начальная температура
    public int CostUpTemp; // Цена повышения температуры в секунду
    public int CostDownTemp; // Цена понижение температуры в секунду
    public int CostSuperUpTemp; // Цена резкого повышения температуры
    public int CostSuperDownTemp; // Цена резкого понижение температуры
    public int CostDropFood; // Цена сброса еды
    public int CostDropWater; // Цена сброса воды
    public int UpTempAmount; // Кол-во поднятия температуры
    public int UpTempTime; // Время поднятия температуры
    public int DownTempAmount; // Кол-во понижения температуры
    public int DownTempTime; // Время понижения температуры
    public int SuperUpTempAmount; // Кол-во резкого повышения температуры
    public int SuperDownTempAmount; //Кол-во резкого понижения температуры


}
