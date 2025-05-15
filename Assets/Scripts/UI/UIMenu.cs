using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject WinText;

    public void Start()
    {
        WinText.SetActive(false);
    }

    public void Awake()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ChooseAlg(GameObject alg)
    {
        _gameManager.CurEvoAlgorithm = alg.GetComponent<IEvoAlgorithm>();
        this.gameObject.SetActive(false);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
