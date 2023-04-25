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
        StartCoroutine(_server.GetServerData());

        SpinCoroutine.StartSpin();

        _uiManager.TurnWinMoneyToZero();
    }

    void StopSpin()
    {
        SpinCoroutine.StopSpin(_server.SlotNumber);

        _uiManager.UpdatedPlayerUI(_server);
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