using UnityEngine;
using System;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private ImageManager _imageManager;
    [SerializeField] private LineManager _lineManager;

    public bool IsOver = false;

    public void StartSpin()
    {
        _imageManager.Spin();
        _lineManager.Spin();
        IsOver = false;
    }

    public void StopSpin(int[] boardNum)
    {
        StartCoroutine(Stop(boardNum));
    }

    public IEnumerator Stop(int[] boardNum)
    {
        _imageManager.Stop(boardNum);

        yield return new WaitUntil(() => _imageManager.CanNextStep == true);

        _lineManager.Stop(boardNum);

        IsOver = true;
    }
}