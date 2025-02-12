using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{

    [SerializeField] private Color _startUpTempButtonColor;
    [SerializeField] private Color _startDownTempButtonColor;
    private Color _stopUpTempButtonColor;
    private Color _stopDownTempButtonColor;

    private GameManager _gameManager;
    private SettingsManager _settingsManager;
    private EnvironmentManager _environmentManager;



    bool _tempUpEnabled = false;
    bool _tempDownEnabled = false;

    bool _upTempCoroutineStart = false;
    bool _downTempCoroutineStart = false;



    public void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _settingsManager = FindFirstObjectByType<SettingsManager>();
        _environmentManager = FindFirstObjectByType<EnvironmentManager>();
    }

    public void UpTempButton(Image button)
    {
        if (!_tempUpEnabled && !_upTempCoroutineStart)
        {
            _tempUpEnabled = true;
            _tempDownEnabled = false;
            _stopUpTempButtonColor = button.color;
            StartCoroutine(UpTempCoroutine(button));
        }
        else if (_tempUpEnabled)
        {
            _tempUpEnabled = false;
        }
    }


    public void DownTempButton(Image button) 
    {
        if (!_tempDownEnabled && !_downTempCoroutineStart)
        {
            _tempDownEnabled = true;
            _tempUpEnabled = false;
            _stopDownTempButtonColor = button.color;
            StartCoroutine(DownTempCoroutine(button));
        }
        else if (_tempDownEnabled)
        {
            _tempDownEnabled = false;
        }
    }


    public void SuperUpTempButton()
    {
        if (_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostSuperUpTemp)
        {
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostSuperUpTemp;
            _environmentManager.SuperUpTemp();
        }
    }

    public void SuperDownTempButton()
    {
        if (_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostSuperDownTemp)
        {
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostSuperDownTemp;
            _environmentManager.SuperDownTemp();
        }
    }

    public void DropFoodButton()
    {
        if (_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostDropFood)
        {
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostDropFood;
            _environmentManager.DropFood();
        }
    }

    public void DropWaterButton()
    {
        if (_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostDropWater)
        {
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostDropWater;
            _environmentManager.DropWater();
        }
    }

    IEnumerator UpTempCoroutine(Image button)
    {
        while ((_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostUpTemp) && _tempUpEnabled)
        {
            _upTempCoroutineStart = true;
            button.color = _startUpTempButtonColor;
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostUpTemp;
            _environmentManager.UpTemp();
            yield return new WaitForSeconds(_settingsManager.NWorldSettings.UpTempTime);
        }
        button.color = _stopUpTempButtonColor;
        _tempUpEnabled = false;
        _upTempCoroutineStart = false;
    }


    IEnumerator DownTempCoroutine(Image button)
    {
        while ((_gameManager.GWorldStats.Points >= _settingsManager.NWorldSettings.CostDownTemp) && _tempDownEnabled)
        {
            _downTempCoroutineStart = true;
            button.color = _startDownTempButtonColor;
            _gameManager.GWorldStats.Points -= _settingsManager.NWorldSettings.CostDownTemp;
            _environmentManager.UpTemp();
            yield return new WaitForSeconds(_settingsManager.NWorldSettings.DownTempTime);
        }
        button.color = _stopDownTempButtonColor;
        _tempDownEnabled = false;
        _downTempCoroutineStart = false;
    }


}
