using System;
using UnityEngine;
using UnityEngine.UI;

public class NormalSpin : SpinBase
{
    public NormalSpin(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        base.SpinHandler();

        if (_SpinBool)
            Rotate();
        else
            Stop();

        _SpinBool = !_SpinBool;
    }
}
