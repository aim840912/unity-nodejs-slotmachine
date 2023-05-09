using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalSpin : SpinBase
{
    public NormalSpin(Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(toggle, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler(int inputValue)
    {
        _uiManager.CloseAllPanel();

        SetToggleText(_spinToggle.isOn);

        if (_spinToggle.isOn)
            StartSpin(inputValue);
        else
            StopSpin();
    }
    public override void StartSpin(int inputValue)
    {
        _mono.StartCoroutine(_gameMode.GetServerData(inputValue));

        _boardManager.Spin();

        _uiManager.TurnWinMoneyToZero();
    }

    public override void StopSpin()
    {
        _mono.StartCoroutine(_boardManager.Stop(_gameMode.BackendData.BoardNum));

        _uiManager.UpdatedPlayerUI(_gameMode);
    }

    private void SetToggleText(bool isSpin)
    {
        _toggleText.text = isSpin ? "Stop" : "Spin";
    }
}
