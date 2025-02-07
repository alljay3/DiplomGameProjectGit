using UnityEngine;
/// <summary>
/// ���������, ��� ����, ��� �� ������ ��������
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
