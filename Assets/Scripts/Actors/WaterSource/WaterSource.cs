using UnityEngine;

/// <summary>
/// ����� ��������� ���� - ��������� ����
/// </summary>

public class WaterSource : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }
}
