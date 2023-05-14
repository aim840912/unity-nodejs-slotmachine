using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MachineRenew : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private UiManager _uiManager;
    private SpinBase spinBase;

    [HeaderAttribute("Game mode")]
    private IGameMode _gameMode;
    [SerializeField] private Server _server;
    [SerializeField] private SingleGame _singleGame;

    private NormalSpin _normalSpin;
    private AutoSpin _autoSpin;


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

        Init();
    }

    private void Init()
    {
        _normalSpin = new NormalSpin(_spinBtn, _uiManager, _boardManager, _gameMode, this);
        _autoSpin = new AutoSpin(_spinBtn, _uiManager, _boardManager, _gameMode, this);
    }

    public void Spin()
    {
        // if (_uiManager.IsBetAvailable())
        //     return;
        if (_uiManager._autoControl.CurrentValue == 0)
        {
            Debug.Log($"_normalSpin");
            spinBase = _normalSpin;
        }
        else
        {
            Debug.Log($"_autoSpin");
            spinBase = _autoSpin;
        }
        spinBase.SpinHandler();
    }



    private int GetBetValue() => _uiManager._betControl.CurrentValue;

}
