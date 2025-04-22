using Unity.VisualScripting;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] public TMPro.TextMeshProUGUI CurrentStage;
    [SerializeField] public TMPro.TextMeshProUGUI CountViruses;
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
    [SerializeField] public TMPro.TextMeshProUGUI UpTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI DownTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI SuperUpTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI SuperDownTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI DropFoodCost;
    [SerializeField] public TMPro.TextMeshProUGUI DropWaterCost;
    [SerializeField] public TMPro.TextMeshProUGUI CurFood;
    [SerializeField] public TMPro.TextMeshProUGUI CurWater;
    [SerializeField] public GameObject VirusPanel; // �������� ������
    [SerializeField] public GameObject BerryPanel; // ������� ������
    [SerializeField] public GameObject WaterSourcePanel; //������ ������

     



    private SettingsManager _settingsManager;

    private GameObject _selectedObject;
    public void Start()
    {
        _gameManager = GameObject.FindFirstObjectByType<GameManager>();
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
    }
    private void FixedUpdate()
    {
        OtherPanel();
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
        ColdResistance.text = _selectedObject.GetComponent<Virus>().Attributes.ColdResistance.ToString();
        HeatResistance.text = _selectedObject.GetComponent<Virus>().Attributes.HeatResistance.ToString();
        MaxHealth.text = _selectedObject.GetComponent<Virus>().Attributes.MaxHealth.ToString();
        HealthRegeneration.text = _selectedObject.GetComponent<Virus>().Attributes.HealthRegeneration.ToString();
        HungerResistance.text = _selectedObject.GetComponent<Virus>().Attributes.HungerResistance.ToString();
        ThirstResistance.text = _selectedObject.GetComponent<Virus>().Attributes.ThirstResistance.ToString();
        AgeImpact.text = _selectedObject.GetComponent<Virus>().Attributes.AgeImpact.ToString();
        MovementSpeed.text = _selectedObject.GetComponent<Virus>().Attributes.MovementSpeed.ToString();
        ComfortTemperature.text = _selectedObject.GetComponent<Virus>().Attributes.ComfortTemperature.ToString();
        CurrentHealth.text = _selectedObject.GetComponent<Virus>().Stats.CurrentHealth.ToString()+ "/" + _selectedObject.GetComponent<Virus>().Stats.CurrentMaxHealth.ToString();
        CurrentHunger.text = _selectedObject.GetComponent<Virus>().Stats.CurrentHunger.ToString() + "/" + _settingsManager.NVirusStatsSettings.DefaultMaxHunger.ToString();
        CurrentThirst.text = _selectedObject.GetComponent<Virus>().Stats.CurrentThirst.ToString() + "/" +  _settingsManager.NVirusStatsSettings.DefaultMaxThirst.ToString();
        CurrentAge.text = _selectedObject.GetComponent<Virus>().Stats.CurrentAge.ToString();

    }
    private void ActiveBerryBushPanel()
    {
        BerryPanel.SetActive(true);
        CurFood.text = _selectedObject.GetComponent<BerryBush>().CurrentFood.ToString() + "/" + _settingsManager.NBerryBushSettings.MaxFood.ToString();
    }
    private void ActiveWaterSourcePanel()
    {
        WaterSourcePanel.SetActive(true);
        CurWater.text = _selectedObject.GetComponent<WaterSource>().CurrentWater.ToString() + "/" + _settingsManager.NWaterSourceSettings.MaxWater.ToString();
    }

    private void OtherPanel()
    {
        CurrentStage.text = _gameManager.GWorldStats.NumberStage.ToString();
        Points.text = _gameManager.GWorldStats.Points.ToString();
        TimeLeft.text = _gameManager.GWorldStats.TimeLeft.ToString();
        Temp.text = _gameManager.GWorldStats.CurTemp.ToString();
        CountViruses.text = _gameManager.CountVirus.ToString();
        UpTempCost.text = _settingsManager.NWorldSettings.CostUpTemp.ToString() + "/" + _settingsManager.NWorldSettings.UpTempTime + "���";
        DownTempCost.text = _settingsManager.NWorldSettings.CostDownTemp.ToString() + "/" + _settingsManager.NWorldSettings.DownTempTime + "���";
        SuperUpTempCost.text = _settingsManager.NWorldSettings.CostSuperUpTemp.ToString() + "/" + _settingsManager.NWorldSettings.SuperUpTempAmount + "���";
        SuperDownTempCost.text = _settingsManager.NWorldSettings.CostSuperDownTemp.ToString() + "/" + _settingsManager.NWorldSettings.SuperDownTempAmount + "���";
        DropFoodCost.text = _settingsManager.NWorldSettings.CostDropFood.ToString() + "/���";
        DropWaterCost.text = _settingsManager.NWorldSettings.CostDropWater.ToString() + "/���";

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
