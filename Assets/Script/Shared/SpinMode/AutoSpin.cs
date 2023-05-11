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

    public AutoSpin(Button spinBtn, Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, toggle, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        base.SpinHandler();
        _mono.StartCoroutine(AutoSpinSequence());
    }

    private IEnumerator AutoSpinSequence()
    {
        for (int i = GetAutoTime(); i > 0; i--)
        {
            CheckAutoCurrentValue();
            StartSpin();
            yield return new WaitForSeconds(3);
            StopSpin();
            yield return new WaitUntil(() => _boardManager.IsOver == true);
        }

        AutoOver();

    }

    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;

    private void CheckAutoCurrentValue()
    {
        _uiManager._autoControl.Minus();
        _uiManager._autoControl.ValueCheck();

    }

    private void AutoOver()
    {
        Debug.Log("auto over");
        _spinToggle.GetComponent<Toggle>().isOn = false;
    }


}
