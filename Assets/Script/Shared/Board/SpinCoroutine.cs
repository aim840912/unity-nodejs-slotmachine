using UnityEngine;
using System;
using System.Collections;

public class SpinCoroutine : MonoBehaviour
{

    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private LineManager _lineManager;

    public void StartSpin()
    {
        _boardManager.Spin();
        _lineManager.Spin();
    }

    public void StopSpin(int[] boardNum)
    {
        StartCoroutine(Stop(boardNum));
    }

    private IEnumerator Stop(int[] boardNum)
    {
        _boardManager.Stop(boardNum);

        yield return new WaitUntil(() => _boardManager.IsOver == true);

        _lineManager.Stop(boardNum);
    }
}