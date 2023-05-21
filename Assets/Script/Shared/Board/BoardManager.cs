using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private ImageManager _imageManager;
    [SerializeField] private LineManager _lineManager;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private AutoButtonControl _autoControl;
    [SerializeField] private TMP_Text _buttonText;

    public bool IsOver { get; private set; } = true;

    public void Spin()
    {
        _imageManager.Spin();
        _lineManager.Spin();

        _uiManager.SetWinToZero();

        ChangeBtnName("Stop");

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

        LoopOneTime();

        yield return new WaitForSeconds(2f);

        ChangeBtnName("Spin");

        IsOver = true;
    }

    private IEnumerator SetBtnInteractableTime()
    {
        _spinBtn.interactable = false;
        yield return new WaitUntil(() => IsOver == true);
        _spinBtn.interactable = true;
    }

    private void ChangeBtnName(string btnName) => _buttonText.text = btnName;

    private void LoopOneTime()
    {
        if (_autoControl.CurrentValue > 0)
        {
            _autoControl.CurrentValue--;
            _autoControl.ValueCheck();
        }
    }
}