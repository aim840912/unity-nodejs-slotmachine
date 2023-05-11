using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalSpin : SpinBase
{
    public NormalSpin(Button spinBtn, Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, toggle, uiManager, boardManager, gameMode, mono)
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
}
