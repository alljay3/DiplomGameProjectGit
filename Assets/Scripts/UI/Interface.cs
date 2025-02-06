using UnityEngine;

public class Interface : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] public TMPro.TextMeshProUGUI CurrentStage;
    [SerializeField] public TMPro.TextMeshProUGUI Points;
    [SerializeField] public TMPro.TextMeshProUGUI TimeLeft;

    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    private void FixedUpdate()
    {
        CurrentStage.text = _gameManager.GWorldStats.NumberStage.ToString();
        Points.text = _gameManager.GWorldStats.Points.ToString();
        TimeLeft.text = _gameManager.GWorldStats.TimeLeft.ToString();
    }



}
