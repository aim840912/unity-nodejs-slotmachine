using UnityEngine;
using System;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private ImageManager _imageManager;
    [SerializeField] private LineManager _lineManager;

    public bool IsOver { get; private set; } = false;

    public void Spin()
    {
        _imageManager.Spin();
        _lineManager.Spin();

        IsOver = false;
    }

    public IEnumerator Stop(int[] boardNum)
    {
        _imageManager.Stop(boardNum);

        yield return new WaitUntil(() => _imageManager.CanNextStep == true);

        _lineManager.Stop(boardNum);

        yield return new WaitForSeconds(2f);

        IsOver = true;
    }
}