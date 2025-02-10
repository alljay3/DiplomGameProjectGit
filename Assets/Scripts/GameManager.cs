using System.Collections;
using UnityEngine;

/// <summary>
/// Класс, отвечающий за мировой 
/// </summary>

public class GameManager : MonoBehaviour
{
    public WorldStats GWorldStats; // Настройки мира

    private SettingsManager _settingsManager;

    private void Start()
    {
        _settingsManager = GameObject.FindFirstObjectByType<SettingsManager>();
        GWorldStats.Points = _settingsManager.NWorldSettings.StartPoints;
        GWorldStats.NumberStage = _settingsManager.NWorldSettings.FirstStage;
        GWorldStats.TimeToNextStage = _settingsManager.NWorldSettings.TimeUntilNextStage;
        GWorldStats.TimeLeft = GWorldStats.TimeToNextStage;
        GWorldStats.CurTemp = _settingsManager.NWorldSettings.FirstTemp;
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
    }
}
