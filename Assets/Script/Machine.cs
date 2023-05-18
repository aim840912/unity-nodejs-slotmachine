using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Machine : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private UiManager _uiManager;

    [HeaderAttribute("Game mode")]
    [SerializeField] private Online _online;
    [SerializeField] private SingleGame _singleGame;

    private NormalSpin _normalSpin;
    private AutoSpin _autoSpin;


    [HeaderAttribute("Bet and Auto Control")]
    [SerializeField] private BetButtonControl _betControl;
    [SerializeField] private AutoButtonControl _autoControl;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _normalSpin = new NormalSpin(_uiManager, _boardManager, GetGameMode(), this);
        _autoSpin = new AutoSpin(_uiManager, _boardManager, GetGameMode(), this);
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

    private SpinBase SetSpinType()
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
        if (!IsBetAvailable())
            return;

        SetSpinType().SpinHandler();
    }

    private bool IsBetAvailable()
    {
        if (PlayerManager.instance.PlayerMoney > _betControl.CurrentValue * _autoControl.CurrentValue)
        {
            return true;
        }

        _betControl.CurrentValue = 0;
        _autoControl.CurrentValue = 0;

        return false;
    }
}