using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private ImageControl _imageControl;
    [SerializeField] private LineControl _lineControl;
    [SerializeField] private Button _spinBtn;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private TMP_Text _buttonText;

    public bool IsOver { get; private set; } = true;

    public void Spin()
    {
        _imageControl.Spin();
        _lineControl.Spin();

        _uiManager.SetWinToZero();

        SetButton(true, "STOP");

        IsOver = false;
    }

    public IEnumerator Stop(BackendData backendData)
    {
        SetButton(false, "SPIN");

        _imageControl.Stop(backendData.BoardNum);

        yield return new WaitUntil(() => _imageControl.IsOver == true);

        _lineControl.Stop(backendData.BoardNum);

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