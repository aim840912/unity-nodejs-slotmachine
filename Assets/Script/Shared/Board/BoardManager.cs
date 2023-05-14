using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private ImageManager _imageManager;
    [SerializeField] private LineManager _lineManager;
    [SerializeField] private Button _spinBtn;

    public bool IsOver { get; private set; } = false;

    public void Spin()
    {
        _imageManager.Spin();
        _lineManager.Spin();

        IsOver = false;
    }

    public IEnumerator Stop(int[] boardNum)
    {
        StartCoroutine(SetBtnInteractableTime());
        _imageManager.Stop(boardNum);

        yield return new WaitUntil(() => _imageManager.CanNextStep == true);

        _lineManager.Stop(boardNum);

        yield return new WaitForSeconds(2f);

        IsOver = true;
    }

    public IEnumerator SetBtnInteractableTime()
    {
        _spinBtn.interactable = false;
        yield return new WaitUntil(() => IsOver == true);
        _spinBtn.interactable = true;

    }
}