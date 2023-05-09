using UnityEngine;
using UnityEngine.UI;

public abstract class SpinBase
{
    protected Toggle _spinToggle;
    protected UiManager _uiManager;
    protected BoardManager _boardManager;
    protected IGameMode _gameMode;
    protected Text _toggleText;
    protected MonoBehaviour _mono;

    public SpinBase(Toggle toggle, UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    {
        Debug.Log("Spin base");
        this._spinToggle = toggle;
        this._uiManager = uiManager;
        this._boardManager = boardManager;
        this._gameMode = gameMode;
        this._mono = mono;

        _toggleText = _spinToggle.GetComponentInChildren<Text>();
    }

    public abstract void SpinHandler(int inputValue);
    public abstract void StartSpin(int inputValue);
    public abstract void StopSpin();
}