using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private ImageManager _imageManager;
    [SerializeField] private LineManager _lineManager;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private UiManager _uiManager;

    public bool IsOver { get; private set; } = true;

    public void Spin()
    {
        _imageManager.Spin();
        _lineManager.Spin();

        _uiManager.SetWinToZero();

        IsOver = false;
    }

    public IEnumerator Stop(BackendData backendData)
    {
        StartCoroutine(SetBtnInteractableTime());

        _imageManager.Stop(backendData.BoardNum);

        yield return new WaitUntil(() => _imageManager.CanNextStep == true);

        _lineManager.Stop(backendData.BoardNum);

        yield return new WaitForSeconds(2f);

        _uiManager.UpdatedPlayerUI(backendData);

        if (_uiManager._autoControl.CurrentValue > 0)
        {
            _uiManager._autoControl.CurrentValue--;
            _uiManager._autoControl.ValueCheck();
        }

        IsOver = true;
    }

    public IEnumerator SetBtnInteractableTime()
    {
        _spinBtn.interactable = false;
        yield return new WaitUntil(() => IsOver == true);
        _spinBtn.interactable = true;

    }
}