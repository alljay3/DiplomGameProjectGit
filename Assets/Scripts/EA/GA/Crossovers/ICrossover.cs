using UnityEngine;

public abstract class ICrossover : MonoBehaviour
{

    public abstract Virus UseCrossover(Virus parrent1, Virus parrent2, Virus virusPref);

}
