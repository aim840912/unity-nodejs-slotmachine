using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpinRenew : SpinBase
{
    Coroutine _coroutine = null;

    public AutoSpinRenew(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(spinBtn, uiManager, boardManager, gameMode, mono)
    { }

    public override void SpinHandler()
    {
        Debug.Log(_boardManager.IsOver);
        if (_boardManager.IsOver)
        {
            _coroutine = _mono.StartCoroutine(NormalAuto());
        }
        else if (!_boardManager.IsOver)
        {
            _mono.StopCoroutine(_coroutine);
            _coroutine = _mono.StartCoroutine(NormalAuto());
        }
    }

    private IEnumerator NormalAuto()
    {
        if (GetAutoTime() < 1)
            yield break;


        if (_boardManager.IsOver == true)
        {
            Debug.Log("rotate()");
            Rotate();
            yield return new WaitForSeconds(3f);
        }


        if (_boardManager.IsOver == false)
        {
            Debug.Log("stop()");
            Stop();
        }

        yield return new WaitUntil(() => _boardManager.IsOver == true);

        _coroutine = _mono.StartCoroutine(NormalAuto());
    }


    private int GetAutoTime() => _uiManager._autoControl.CurrentValue;
}
