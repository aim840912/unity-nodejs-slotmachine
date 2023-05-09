using System;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{

    public AutoSpin(Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(toggle, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler(int inputValue)
    {
        throw new NotImplementedException();
    }

    public override void StartSpin(int inputValue)
    {
        throw new NotImplementedException();
    }

    public override void StopSpin()
    {
        throw new NotImplementedException();
    }
}
