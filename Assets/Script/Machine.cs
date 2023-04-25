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
    [SerializeField] private Server _server;
    [SerializeField] private SingleGame _singleGame;

    private IGameMode _gameMode;

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

        _uiManager.UpdatedPlayerUI(_gameMode);

    }

    public void SpinToggleOnClick()
    {
        _uiManager.CloseAllPanel();

        if (_spinToggle.isOn)
        {
            StartSpin();
        }
        else
        {
            StopSpin();
        }
    }

    void StartSpin()
    {
        StartCoroutine(_gameMode.GetServerData());

        SpinCoroutine.StartSpin();

        _uiManager.TurnWinMoneyToZero();
    }

    void StopSpin()
    {
        SpinCoroutine.StopSpin(_gameMode.SlotNumber);

        _uiManager.UpdatedPlayerUI(_gameMode);
    }

    public void Auto(int time)
    {
        StartCoroutine(AutoSpin(time));
    }

    private IEnumerator AutoSpin(int time)
    {
        for (int i = 0; i < time; i++)
        {
            StartSpin();
            yield return new WaitForSecondsRealtime(5);
            StopSpin();
            yield return new WaitForSecondsRealtime(5);
        }
    }
}