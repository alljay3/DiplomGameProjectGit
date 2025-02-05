using UnityEngine;

/// <summary>
/// Класс вируса
/// </summary>

public class  Virus : MonoBehaviour
{
    public VirusStats Stats;
    public VirusAttrubutes Attrubutes;

    [SerializeField] private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
}
