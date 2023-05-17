using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Machine : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private UiManager _uiManager;
    private SpinBase spinBase;

    [HeaderAttribute("Game mode")]
    [SerializeField] private Online _online;
    [SerializeField] private SingleGame _singleGame;

    [Header("Spin")]
    private NormalSpin _normalSpin;
    private AutoSpin _autoSpin;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _normalSpin = new NormalSpin(_spinBtn, _uiManager, _boardManager, GetGameMode(), this);
        _autoSpin = new AutoSpin(_spinBtn, _uiManager, _boardManager, GetGameMode(), this);
    }

    private IGameMode GetGameMode()
    {
        switch (GameManager.Instance.GameMode)
        {
            case GameMode.ONLINE:
                return _online;
            case GameMode.SINGLE_GAME:
                return _singleGame;
            default:
                return _singleGame;
        }
    }

    private SpinBase GetSpinType()
    {
        if (_uiManager._autoControl.CurrentValue == 0)
        {
            Debug.Log($"_normalSpin");
            return _normalSpin;
        }
        else
        {
            Debug.Log($"_autoSpin");
            return _autoSpin;
        }
    }


    public void Spin()
    {
        if (!_uiManager.IsBetAvailable())
            return;

        GetSpinType().SpinHandler();
    }
}