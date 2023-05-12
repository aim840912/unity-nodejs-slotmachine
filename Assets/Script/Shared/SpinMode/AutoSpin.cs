using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{
    public AutoSpin(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        base.SpinHandler();
        if (_SpinBool == true)
        {
            _mono.StartCoroutine(Auto());
            _SpinBool = !_SpinBool;
        }
        else
        {
            SetAutoToZero();
            _SpinBool = true;
        }

    }

    private IEnumerator Auto()
    {
        while (_SpinBool)
        {
            Rotate();
            yield return new WaitForSeconds(3);
            Stop();
            yield return new WaitUntil(() => _boardManager.IsOver == true);
            if (_uiManager._autoControl.CurrentValue > 0)
            {
                _uiManager._autoControl.CurrentValue--;
            }
            _uiManager._autoControl.ValueCheck();
            _SpinBool = IsOver();
        }
        _SpinBool = true;
    }

    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;

    private void SetAutoToZero()
    {
        _uiManager._autoControl.CurrentValue = 0;
        _uiManager._autoControl.ValueCheck();
    }

    private bool IsOver()
    {
        if (GetAutoTime() > 0)
            return true;
        else
            return false;
    }
}
