using UnityEngine;

[System.Serializable]
/// <summary>
/// Стандартные настройки вируса, не изменяются по ходу игры.
/// </summary>
public struct VirusSettings
{
    public int DefaultVirusTempDmg; // Стандартный урон от температуры
    public int DefaultVirusHungerDmg; // Стандартный урон от голода
    public int DefaultVirusThirstDmg; // Стандартный урон от жажды
    public int DefaultTimeTakeDmg; // Стандартное время для получение урона
    public int DefaultHealthRegeneration; // Стандартная регенерация здоровья
    public float DefaultScaleTempDmg; // Увеличение урона от температуры


    public float HungerDepletionSpeed; // Скорость голодания
    public int HungerDepletionAmount; // Количество голодания
    public float EatDepletionSpeed; // Скорость с который питается вирус
    public int EatDepletionAmount; // кол-во с которым питается вирус
    public int EatThreshold; //  пороговое значение в процентах, при котором нужно поесть.


    public float waterDepletionSpeed; // Скрорость уменьшение воды    
    public int waterDepletionAmount; // Кол-во уменьшение воды
    public float DrinkDepletionSpeed; // Скорость питья
    public int DrinkDepletionAmount; // Кол-во питья
    public int DrinkThreshold; // пороговое значение, при котором нужно попить.

    public int MinFoodToEat; // Пороговое значение, при котором можно идти к кусту
    public int MinWaterToDrink; // Пороговое значение, при котором можно идти к кусту

}
