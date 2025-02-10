using Unity.VisualScripting;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] public TMPro.TextMeshProUGUI CurrentStage;
    [SerializeField] public TMPro.TextMeshProUGUI Points;
    [SerializeField] public TMPro.TextMeshProUGUI TimeLeft;
    [SerializeField] public TMPro.TextMeshProUGUI Temp;
    [SerializeField] public TMPro.TextMeshProUGUI ColdResistance;       // ������������� ������
    [SerializeField] public TMPro.TextMeshProUGUI HeatResistance;       // ������������� ����
    [SerializeField] public TMPro.TextMeshProUGUI MaxHealth;            // �������� (�����)
    [SerializeField] public TMPro.TextMeshProUGUI HealthRegeneration;   // �������������� ��������
    [SerializeField] public TMPro.TextMeshProUGUI HungerResistance;     // ������������� ������
    [SerializeField] public TMPro.TextMeshProUGUI ThirstResistance;     // ������������� �����
    [SerializeField] public TMPro.TextMeshProUGUI AgeImpact;            // ������� ��������
    [SerializeField] public TMPro.TextMeshProUGUI MovementSpeed;        // �������� �����������
    [SerializeField] public TMPro.TextMeshProUGUI ComfortTemperature;   // ���������� �����������
    [SerializeField] public TMPro.TextMeshProUGUI CurrentHealth; // ������� �����
    [SerializeField] public TMPro.TextMeshProUGUI CurrentHunger; // ������� �����
    [SerializeField] public TMPro.TextMeshProUGUI CurrentThirst; // ������� �����
    [SerializeField] public TMPro.TextMeshProUGUI CurrentAge;    // ������� �������
    [SerializeField] public GameObject VirusPanel;
    [SerializeField] public GameObject BerryPanel;
    [SerializeField] public GameObject WaterSourcePanel;
    private SettingsManager _settingsManager;

    private GameObject _selectedObject;
    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
    }
    private void FixedUpdate()
    {
        UpPanel();
        DisableAllDownPanel();
        if (_selectedObject != null)
        {
            if (_selectedObject.TryGetComponent<Virus>(out Virus virus))
                ActiveVirusPanel();
            if (_selectedObject.TryGetComponent<BerryBush>(out BerryBush berry))
                ActiveBerryBushPanel();
            if (_selectedObject.TryGetComponent<WaterSource>(out WaterSource water))
                ActiveWaterSourcePanel();
        }
    }
    private void DisableAllDownPanel()
    {
        VirusPanel.SetActive(false);
        BerryPanel.SetActive(false);
        WaterSourcePanel.SetActive(false);
    }
    private void ActiveVirusPanel()
    {
        VirusPanel.SetActive(true);
        ColdResistance.text = _selectedObject.GetComponent<Virus>().Attrubutes.ColdResistance.ToString();
        HeatResistance.text = _selectedObject.GetComponent<Virus>().Attrubutes.HeatResistance.ToString();
        MaxHealth.text = _selectedObject.GetComponent<Virus>().Attrubutes.MaxHealth.ToString();
        HealthRegeneration.text = _selectedObject.GetComponent<Virus>().Attrubutes.HealthRegeneration.ToString();
        HungerResistance.text = _selectedObject.GetComponent<Virus>().Attrubutes.HungerResistance.ToString();
        ThirstResistance.text = _selectedObject.GetComponent<Virus>().Attrubutes.ThirstResistance.ToString();
        AgeImpact.text = _selectedObject.GetComponent<Virus>().Attrubutes.AgeImpact.ToString();
        MovementSpeed.text = _selectedObject.GetComponent<Virus>().Attrubutes.MovementSpeed.ToString();
        ComfortTemperature.text = _selectedObject.GetComponent<Virus>().Attrubutes.ComfortTemperature.ToString();
        CurrentHealth.text = _selectedObject.GetComponent<Virus>().Stats.CurrentHealth.ToString()+ "/" + _selectedObject.GetComponent<Virus>().Stats.CurrentMaxHealth.ToString();
        CurrentHunger.text = _selectedObject.GetComponent<Virus>().Stats.CurrentHunger.ToString() + "/" + _settingsManager.NVirusStatsSettings.DefaultMaxHunger.ToString();
        CurrentThirst.text = _selectedObject.GetComponent<Virus>().Stats.CurrentThirst.ToString() + "/" +  _settingsManager.NVirusStatsSettings.DefaultMaxThirst.ToString();
        CurrentAge.text = _selectedObject.GetComponent<Virus>().Stats.CurrentAge.ToString();

    }
    private void ActiveBerryBushPanel()
    {
        BerryPanel.SetActive(true);
    }
    private void ActiveWaterSourcePanel()
    {
        WaterSourcePanel.SetActive(true);
    }

    private void UpPanel()
    {
        CurrentStage.text = _gameManager.GWorldStats.NumberStage.ToString();
        Points.text = _gameManager.GWorldStats.Points.ToString();
        TimeLeft.text = _gameManager.GWorldStats.TimeLeft.ToString();
        Temp.text = _gameManager.GWorldStats.CurTemp.ToString();
    }

    public void SetSelectedObject(GameObject obj)
    {
        _selectedObject = obj;
    }

    public void SetSelectedObjectNull()
    {
        SetSelectedObject(null);
    }
}
