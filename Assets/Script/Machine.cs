using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Machine : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;

    [HeaderAttribute("Game mode")]
    [SerializeField] private SingleGame _singleGame;
    private Online _online = new Online();

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
        _normalSpin = new NormalSpin(_betControl, _autoControl, _boardManager, GetGameMode(), this);
        _autoSpin = new AutoSpin(_betControl, _autoControl, _boardManager, GetGameMode(), this);
    }

    private IGameMode GetGameMode() => GameManager.Instance.GameMode == GameMode.ONLINE ? _online : _singleGame;

    private SpinBase SetSpinType() => _autoControl.CurrentValue == 0 ? _normalSpin : _autoSpin;


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