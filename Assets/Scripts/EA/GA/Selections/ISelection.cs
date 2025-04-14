using NUnit.Framework;
using UnityEngine;

public abstract class ISelection : MonoBehaviour
{
    public abstract Virus[] UseSelection(Virus[] viruses, float[] fitnessValues);
}
