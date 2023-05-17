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
        if (_boardManager.IsOver)
        {
            Rotate();
        }
        else
        {
            Stop();
        }
    }
}
