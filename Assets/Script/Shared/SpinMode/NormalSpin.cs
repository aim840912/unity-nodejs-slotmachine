using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalSpin : SpinBase
{
    public NormalSpin(Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(toggle, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        base.SpinHandler();

        SetToggleText(_spinToggle.isOn);

        if (_spinToggle.isOn)
            StartSpin();
        else
            StopSpin();
    }
    protected override void StartSpin()
    {
        _mono.StartCoroutine(_gameMode.GetServerData(GetInputValue()));

        _boardManager.Spin();

        _uiManager.TurnWinMoneyToZero();
    }

    protected override void StopSpin()
    {
        _mono.StartCoroutine(_boardManager.Stop(_gameMode.BackendData.BoardNum));

        _uiManager.UpdatedPlayerUI(_gameMode);
    }

}
