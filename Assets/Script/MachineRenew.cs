using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MachineRenew : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Toggle _spinToggle;
    [SerializeField] private UiManager _uiManager;
    private SpinBase spinBase;

    [HeaderAttribute("Game mode")]
    private IGameMode _gameMode;
    [SerializeField] private Server _server;
    [SerializeField] private SingleGame _singleGame;

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

        spinBase = new NormalSpin(_spinToggle, _uiManager, _boardManager, _gameMode, this);
    }

    public void Spin()
    {
        // if (_uiManager.IsBetAvailable())
        //     return;

        spinBase.SpinHandler();
    }


    private int GetBetValue() => _uiManager._betControl.CurrentValue;

}
