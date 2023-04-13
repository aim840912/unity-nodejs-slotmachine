using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Machine : MonoBehaviour
{
    public SpinCoroutine SpinCoroutine;

    [SerializeField] private Toggle _spinToggle;
    [SerializeField] private UiManager _uiManager;
    private Server _server = new Server();
    private int _inputValue = 1;

    public void SpinToggleOnClick()
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

    void StartSpin()
    {
        SpinCoroutine.StartSpin();
        _server.ServerStep(_inputValue);
    }

    void StopSpin()
    {
        SpinCoroutine.StopSpin(_server.GetBoard());
        _uiManager.UpdatedPlayerUI(_server);
    }

}