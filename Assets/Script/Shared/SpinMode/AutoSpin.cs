using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{
    private Coroutine _coroutine = null;

    public AutoSpin(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        if (_coroutine != null)
        {
            _mono.StopCoroutine(_coroutine);
        }
        _coroutine = _mono.StartCoroutine(NormalAuto());
    }

    private IEnumerator NormalAuto()
    {
        if (GetAutoTime() < 1)
            yield break;

        if (_boardManager.IsOver == true)
        {
            Rotate();
            yield return new WaitForSeconds(3f);
        }

        if (_boardManager.IsOver == false)
        {
            Stop();
        }

        yield return new WaitUntil(() => _boardManager.IsOver == true);

        _coroutine = _mono.StartCoroutine(NormalAuto());
    }


    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;
}
