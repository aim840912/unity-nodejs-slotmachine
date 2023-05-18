using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public abstract class SpinBase
{
    protected Button _spinBtn;
    protected UiManager _uiManager;
    protected BoardManager _boardManager;
    protected IGameMode _gameMode;
    protected MonoBehaviour _mono;
    private TMP_Text _buttonText;

    public SpinBase(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    {
        this._spinBtn = spinBtn;
        this._uiManager = uiManager;
        this._boardManager = boardManager;
        this._gameMode = gameMode;
        this._mono = mono;

        _buttonText = _spinBtn.GetComponentInChildren<TMP_Text>();
    }

    public abstract void SpinHandler();

    protected virtual void Rotate()
    {
        _mono.StartCoroutine(_gameMode.GetServerData(GetInputValue()));

        _boardManager.Spin();

        ChangeBtnName("Stop");
    }

    protected virtual void Stop()
    {
        _mono.StartCoroutine(_boardManager.Stop(_gameMode.BackendData));

        ChangeBtnName("Spin");
    }

    protected virtual int GetInputValue() => _uiManager._betControl.CurrentValue;

    private IEnumerator SetBtnInteractableTime(float interactableTime)
    {
        _spinBtn.interactable = false;
        yield return new WaitForSeconds(interactableTime);
        _spinBtn.interactable = true;
    }

    private void ChangeBtnName(string btnName)
    {
        _buttonText.text = btnName;
    }
}