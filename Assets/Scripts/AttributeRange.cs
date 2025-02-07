using UnityEngine;
/// <summary>
/// —труктура, дл€ того, что бы задать диапозон
/// </summary>
/// 
[System.Serializable]
public struct AttributeRange
{
    public int Min;
    public int Max;

    public AttributeRange(int min, int max)
    {
        Min = min;
        Max = max;
    }
}
