using System.Collections;
using UnityEngine;

/// <summary>
/// �����, ���������� �� ������� 
/// </summary>

public class GameManager : MonoBehaviour
{
    public WorldStats GWorldStats; // ��������� ����
    public Virus VirusPref;
    public BerryBush BerryBushPref;
    public WaterSource WaterSourcePref;
    public IEvoAlgorithm CurEvoAlgorithm;

    [HideInInspector] public int AllFood;
    [HideInInspector] public int AllWater;
    [HideInInspector] public int countWaterSources;
    [HideInInspector] public int CountBushes;
    [HideInInspector] public int CountVirus;

    private SettingsManager _settingsManager;

    private void Start()
    {
        CountVirus = 0;
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        GWorldStats.Points = _settingsManager.NWorldSettings.StartPoints;
        GWorldStats.NumberStage = _settingsManager.NWorldSettings.FirstStage;
        GWorldStats.TimeToNextStage = _settingsManager.NWorldSettings.TimeUntilNextStage;
        GWorldStats.TimeLeft = GWorldStats.TimeToNextStage;
        GWorldStats.CurTemp = _settingsManager.NWorldSettings.FirstTemp;
        SpawnFirstVirus();
        StartCoroutine(CountdownToNextStage());
    }

    private IEnumerator CountdownToNextStage()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GWorldStats.TimeLeft -= 1;
            if (GWorldStats.TimeLeft <= 0)
            {
                GWorldStats.TimeLeft = GWorldStats.TimeToNextStage;
                NextStage();
            }
        }
    }

    private void FixedUpdate()
    {
        CountVirus = FindObjectsByType<Virus>(FindObjectsSortMode.None).Length;
    }

    private void NextStage()
    {
        GWorldStats.NumberStage += 1;
        Virus[] viruses = FindObjectsByType<Virus>(FindObjectsSortMode.None);
        foreach (var virus in viruses)
            virus.NextStage();
        GWorldStats.Points += viruses.Length * _settingsManager.NWorldSettings.VirusCountScore;

        BerryBush[] berryBushes = FindObjectsByType<BerryBush>(FindObjectsSortMode.None);
        WaterSource[] waterSource = FindObjectsByType<WaterSource>(FindObjectsSortMode.None);
        AllFood = 0;
        AllWater = 0;
        foreach (var water in waterSource)
        {
            AllWater += water.CurrentWater;
        }
        foreach (var bush in berryBushes)
        {
            AllFood += bush.CurrentFood;
        }
        CountBushes = berryBushes.Length;
        countWaterSources = waterSource.Length;

        CurEvoAlgorithm.BeginReproduction();
    }

    private void SpawnFirstVirus()
    {
        for (int i = 0; i < _settingsManager.NWorldSettings.FirstVirusCount; i++)
            GameObject.Instantiate(VirusPref, new Vector3(Random.Range(_settingsManager.NWorldSettings.GameFieldMinX, _settingsManager.NWorldSettings.GameFieldMaxX), Random.Range(_settingsManager.NWorldSettings.GameFieldMinY, _settingsManager.NWorldSettings.GameFieldMaxY), 0), Quaternion.identity);
        for (int i = 0; i < _settingsManager.NWorldSettings.FirstBerryBushCount; i++)
            GameObject.Instantiate(BerryBushPref, new Vector3(Random.Range(_settingsManager.NWorldSettings.GameFieldMinX, _settingsManager.NWorldSettings.GameFieldMaxX), Random.Range(_settingsManager.NWorldSettings.GameFieldMinY, _settingsManager.NWorldSettings.GameFieldMaxY), 0), Quaternion.identity);
        for (int i = 0; i < _settingsManager.NWorldSettings.FirstWaterSourceCount; i++)
            GameObject.Instantiate(WaterSourcePref, new Vector3(Random.Range(_settingsManager.NWorldSettings.GameFieldMinX, _settingsManager.NWorldSettings.GameFieldMaxX), Random.Range(_settingsManager.NWorldSettings.GameFieldMinY, _settingsManager.NWorldSettings.GameFieldMaxY), 0), Quaternion.identity);
    }
}
