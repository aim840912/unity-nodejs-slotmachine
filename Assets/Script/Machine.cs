using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Machine : MonoBehaviour
{
    public SpinCoroutine SpinCoroutine;

    [SerializeField] private Toggle _spinToggle;
    [SerializeField] private UiManager _uiManager;
    [Space(15)]
    [SerializeField] private Server _server;
    [SerializeField] private SingleGame _singleGame;
    private IGameMode _gameMode;

    private int _autoSpinTimes;


    private void Start()
    {
        if (GameManager.instance._scenePattern == ScenePattern.ONLINE)
        {
            _gameMode = _server;
        }
        else if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
        {
            _gameMode = _singleGame;
        }

        StartCoroutine(WaitForGetData());

    }

    private IEnumerator WaitForGetData()
    {
        yield return new WaitUntil(() => _gameMode.GetData);

        _uiManager.UpdatedPlayerUI(_gameMode);
    }


    public void SpinToggleOnClick()
    {
        _uiManager.CloseAllPanel();

        _autoSpinTimes = _uiManager._autoControl.CurrentValue;

        if (_autoSpinTimes > 0)
        {
            StartCoroutine(AutoSpin(_autoSpinTimes));
        }
        else
        {
            NormalSpin();
        }
    }

    private void NormalSpin()
    {
        if (_spinToggle.isOn)
        {
            StartSpin();
        }
        else
        {
            StopSpin();
        }
    }

    private IEnumerator AutoSpin(int time)
    {
        for (int i = 0; i < time; i++)
        {
            --_uiManager._autoControl.CurrentValue;
            StartSpin();
            yield return new WaitForSecondsRealtime(3);
            StopSpin();
            yield return new WaitForSecondsRealtime(3);

        }
    }

    void StartSpin()
    {
        StartCoroutine(_gameMode.GetServerData(_uiManager._betControl.CurrentValue));

        SpinCoroutine.StartSpin();

        _uiManager.TurnWinMoneyToZero();
    }

    void StopSpin()
    {
        SpinCoroutine.StopSpin(_gameMode.SlotNumber);

        _uiManager.UpdatedPlayerUI(_gameMode);
    }


}