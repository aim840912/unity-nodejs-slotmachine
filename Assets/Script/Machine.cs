using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Machine : MonoBehaviour
{
    public SpinCoroutine SpinCoroutine;

    [SerializeField] private Toggle _spinToggle;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private Server _server;

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

        StartCoroutine(_server.ServerCor());
    }

    void StopSpin()
    {
        SpinCoroutine.StopSpin(_server.SlotNumber);
        _uiManager.UpdatedPlayerUI(_server);
    }

}