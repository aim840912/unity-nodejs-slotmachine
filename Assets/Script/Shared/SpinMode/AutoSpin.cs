using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{
    private bool _isCrRunning = false;
    public AutoSpin(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        if (_isCrRunning == false)
            _mono.StartCoroutine(NormalAuto());
        else
        {
            _mono.StopAllCoroutines();
            _mono.StartCoroutine(StopAutoAndRestart());
        }
    }

    private IEnumerator NormalAuto()
    {

        if (GetAutoTime() < 1)
            yield break;
        _isCrRunning = true;

        if (_SpinBool == true)
        {
            Rotate();
            yield return new WaitForSeconds(3);
        }

        Stop();

        yield return new WaitUntil(() => _boardManager.IsOver == true);

        if (_uiManager._autoControl.CurrentValue > 0)
        {
            _uiManager._autoControl.CurrentValue--;
        }
        _uiManager._autoControl.ValueCheck();

        _isCrRunning = false;

        _mono.StartCoroutine(NormalAuto());
    }

    private IEnumerator StopAutoAndRestart()
    {

        Stop();
        yield return new WaitUntil(() => _boardManager.IsOver == true);

        if (_uiManager._autoControl.CurrentValue > 0)
        {
            _uiManager._autoControl.CurrentValue--;
        }
        _uiManager._autoControl.ValueCheck();

        _isCrRunning = false;

        _mono.StartCoroutine(NormalAuto());

    }


    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;


}
