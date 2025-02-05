using UnityEngine;


/// <summary>
/// ����� ����� - ��������� ����
/// </summary>
public class BerryBush : MonoBehaviour
{

    public int MaxFood;
    public int CurrentFood;


    [SerializeField] private GameManager _gameManager;


    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
}
