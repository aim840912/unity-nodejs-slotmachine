using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class SpinBase
{
    protected Button _spinBtn;
    protected UiManager _uiManager;
    protected BoardManager _boardManager;
    protected IGameMode _gameMode;
    protected Text _toggleText;
    protected TMP_Text _buttonText;
    protected MonoBehaviour _mono;
    protected bool _SpinBool = true;

    public SpinBase(Button spinBtn, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    {
        this._spinBtn = spinBtn;
        this._uiManager = uiManager;
        this._boardManager = boardManager;
        this._gameMode = gameMode;
        this._mono = mono;

        _buttonText = _spinBtn.GetComponentInChildren<TMP_Text>();
    }

    public virtual void SpinHandler()
    {
        _uiManager.CloseAllPanel();
    }

    protected virtual void Rotate()
    {
        _mono.StartCoroutine(_gameMode.GetServerData(GetInputValue()));

        _boardManager.Spin();

        _uiManager.TurnWinMoneyToZero();
    }

    protected virtual void Stop()
    {
        _mono.StartCoroutine(_boardManager.Stop(_gameMode.BackendData.BoardNum));

        _uiManager.UpdatedPlayerUI(_gameMode);
    }

    protected virtual int GetInputValue() => _uiManager._betControl.CurrentValue;
}