using UnityEngine;

/// <summary>
/// Класс вируса
/// </summary>

public class  Virus : MonoBehaviour
{
    public VirusStats Stats; // Статусы вируса
    public VirusAttrubutes Attrubutes; // Атрибуты вируса

    private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
}
