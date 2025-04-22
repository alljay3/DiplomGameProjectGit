using UnityEngine;

public abstract class IOtgSelection : MonoBehaviour
{
    public abstract Virus[] UseSelection(Virus[] viruses, float[] fitnessValues);

}
