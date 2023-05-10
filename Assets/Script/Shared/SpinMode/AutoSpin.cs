using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{
    private int AutoSpinTime
    {
        get
        {
            return _uiManager._autoControl.CurrentValue;
        }
    }

    public AutoSpin(Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(toggle, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        _mono.StartCoroutine(AutoSpinSequence());
    }

    protected override void StartSpin()
    {
        throw new NotImplementedException();
    }

    protected override void StopSpin()
    {
        throw new NotImplementedException();
    }

    private IEnumerator AutoSpinSequence()
    {
        for (int i = 0; i < GetAutoTime(); i++)
        {
            StartSpin();
            yield return new WaitForSeconds(31);
            StopSpin();
            yield return new WaitUntil(() => _boardManager.IsOver == true);
            DecreaseAutoTime();
        }
    }

    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;

    private int DecreaseAutoTime() => _uiManager._autoControl.CurrentValue--;


}
