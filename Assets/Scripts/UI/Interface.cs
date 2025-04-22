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
    [SerializeField] public TMPro.TextMeshProUGUI ColdResistance;       // Сопротивление холоду
    [SerializeField] public TMPro.TextMeshProUGUI HeatResistance;       // Сопротивление жаре
    [SerializeField] public TMPro.TextMeshProUGUI MaxHealth;            // Здоровье (общее)
    [SerializeField] public TMPro.TextMeshProUGUI HealthRegeneration;   // Восстановление здоровья
    [SerializeField] public TMPro.TextMeshProUGUI HungerResistance;     // Сопротивление голоду
    [SerializeField] public TMPro.TextMeshProUGUI ThirstResistance;     // Сопротивление жажде
    [SerializeField] public TMPro.TextMeshProUGUI AgeImpact;            // Влияние возраста
    [SerializeField] public TMPro.TextMeshProUGUI MovementSpeed;        // Скорость перемещения
    [SerializeField] public TMPro.TextMeshProUGUI ComfortTemperature;   // Комфортная температура
    [SerializeField] public TMPro.TextMeshProUGUI CurrentHealth; // Текущие жизни
    [SerializeField] public TMPro.TextMeshProUGUI CurrentHunger; // Текущий голод
    [SerializeField] public TMPro.TextMeshProUGUI CurrentThirst; // Текущая жажда
    [SerializeField] public TMPro.TextMeshProUGUI CurrentAge;    // Текущий возраст
    [SerializeField] public TMPro.TextMeshProUGUI UpTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI DownTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI SuperUpTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI SuperDownTempCost;
    [SerializeField] public TMPro.TextMeshProUGUI DropFoodCost;
    [SerializeField] public TMPro.TextMeshProUGUI DropWaterCost;
    [SerializeField] public TMPro.TextMeshProUGUI CurFood;
    [SerializeField] public TMPro.TextMeshProUGUI CurWater;
    [SerializeField] public GameObject VirusPanel; // Вирусная панель
    [SerializeField] public GameObject BerryPanel; // Ягодная панель
    [SerializeField] public GameObject WaterSourcePanel; //Водная панель

     



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
        UpTempCost.text = _settingsManager.NWorldSettings.CostUpTemp.ToString() + "/" + _settingsManager.NWorldSettings.UpTempTime + "сек";
        DownTempCost.text = _settingsManager.NWorldSettings.CostDownTemp.ToString() + "/" + _settingsManager.NWorldSettings.DownTempTime + "сек";
        SuperUpTempCost.text = _settingsManager.NWorldSettings.CostSuperUpTemp.ToString() + "/" + _settingsManager.NWorldSettings.SuperUpTempAmount + "раз";
        SuperDownTempCost.text = _settingsManager.NWorldSettings.CostSuperDownTemp.ToString() + "/" + _settingsManager.NWorldSettings.SuperDownTempAmount + "раз";
        DropFoodCost.text = _settingsManager.NWorldSettings.CostDropFood.ToString() + "/раз";
        DropWaterCost.text = _settingsManager.NWorldSettings.CostDropWater.ToString() + "/раз";

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
