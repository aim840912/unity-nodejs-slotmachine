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
    [SerializeField] private TMP_Text _buttonText;

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
        SetButton(false, "STOP");

        _imageManager.Stop(backendData.BoardNum);

        yield return new WaitUntil(() => _imageManager.CanNextStep == true);

        _lineManager.Stop(backendData.BoardNum);

        yield return new WaitForSeconds(2f);

        _uiManager.UpdatedPlayerUI(backendData);

        yield return new WaitForSeconds(1f);

        SetButton(true, "SPIN");
        IsOver = true;
    }


    private void SetButton(bool isInteractable, string btnName)
    {
        _spinBtn.interactable = isInteractable;
        ChangeBtnName(btnName);
    }

    private void ChangeBtnName(string btnName) => _buttonText.text = btnName;
}