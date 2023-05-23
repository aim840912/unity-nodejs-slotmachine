using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AutoSpin : SpinBase
{
    private Coroutine _coroutine = null;
    private float _loopStopTime = 3f;

    public AutoSpin(BetButtonControl betControl, AutoButtonControl autoControl, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    : base(betControl, autoControl, boardManager, gameMode, mono)
    {
    }

    public override void SpinHandler()
    {
        if (_coroutine != null)
        {
            _mono.StopCoroutine(_coroutine);
        }
        _coroutine = _mono.StartCoroutine(Auto());
    }

    private IEnumerator Auto()
    {
        if (GetAutoValue() < 1)
            yield break;

        if (_boardManager.IsOver == true)
        {
            Rotate();
            yield return new WaitForSeconds(_loopStopTime);
        }

        if (_boardManager.IsOver == false)
        {
            Stop();
        }

        yield return new WaitUntil(() => _boardManager.IsOver == true);

        _autoControl.LoopOverOneTime();

        _coroutine = _mono.StartCoroutine(Auto());
    }


    private int GetAutoValue() => _autoControl.CurrentValue;
}
