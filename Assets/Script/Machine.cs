using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Machine : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Toggle _spinToggle;
    [Space(15)]
    [SerializeField] private UiManager _uiManager;
    [Space(15)]
    [SerializeField] private Server _server;
    [SerializeField] private SingleGame _singleGame;
    private IGameMode _gameMode;

    private int _autoSpinTimes;


    private void Start()
    {
        if (GameManager.Instance.GameMode == GameMode.ONLINE)
        {
            _gameMode = _server;
        }
        else if (GameManager.Instance.GameMode == GameMode.SINGLE_GAME)
        {
            _gameMode = _singleGame;
        }

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
            yield return new WaitUntil(() => _boardManager.IsOver == true);
        }
    }

    void StartSpin()
    {
        StartCoroutine(_gameMode.GetServerData(_uiManager._betControl.CurrentValue));

        _boardManager.Spin();

        _uiManager.TurnWinMoneyToZero();
    }

    void StopSpin()
    {
        StartCoroutine(_boardManager.Stop(_gameMode.BackendData.BoardNum));

        _uiManager.UpdatedPlayerUI(_gameMode);
    }

}