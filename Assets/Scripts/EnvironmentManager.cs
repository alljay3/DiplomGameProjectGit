using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private GameManager _gameManager;
    private SettingsManager _settingsManager;

    public void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _settingsManager = FindFirstObjectByType<SettingsManager>();
    }

    public void UpTemp()
    {
        _gameManager.GWorldStats.CurTemp += _settingsManager.NWorldSettings.UpTempAmount;
    }

    public void DownTemp()
    {
        _gameManager.GWorldStats.CurTemp -= _settingsManager.NWorldSettings.DownTempAmount;
    }

    public void SuperUpTemp()
    {
        _gameManager.GWorldStats.CurTemp += _settingsManager.NWorldSettings.SuperUpTempAmount;
    }

    public void SuperDownTemp()
    {
        _gameManager.GWorldStats.CurTemp -= _settingsManager.NWorldSettings.SuperDownTempAmount;
    }

    public void DropFood()
    {
        BerryBush[] berryBushes = GameObject.FindObjectsByType<BerryBush>(FindObjectsSortMode.None);
        foreach (BerryBush berryBush in berryBushes)
        {
            berryBush.DropCurFood();
        }
    }

    public void DropWater()
    {
        WaterSource[] waterSources = GameObject.FindObjectsByType<WaterSource>(FindObjectsSortMode.None);
        foreach (WaterSource waterSource in waterSources)
        {
            waterSource.DropCurWater();
        }
    }
}
