using System.Collections;
using UnityEngine;

/// <summary>
/// Класс, отвечающий за мировой 
/// </summary>

public class GameManager : MonoBehaviour
{
    public WorldStats GWorldStats; // Настройки мира
    public Virus VirusPref;
    public BerryBush BerryBushPref;
    public WaterSource WaterSourcePref;
    public EvoAlgorithm CurEvoAlgorithm;

    private SettingsManager _settingsManager;

    private void Start()
    {
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

    private void NextStage()
    {
        GWorldStats.NumberStage += 1;
        Virus[] viruses = FindObjectsByType<Virus>(FindObjectsSortMode.None);
        foreach (var virus in viruses)
            virus.NextStage();
        GWorldStats.Points += viruses.Length * _settingsManager.NWorldSettings.VirusCountScore;
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
