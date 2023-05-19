using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public abstract class SpinBase
{
    protected BetButtonControl _betControl;
    protected AutoButtonControl _autoControl;

    protected BoardManager _boardManager;
    protected IGameMode _gameMode;
    protected MonoBehaviour _mono;

    public SpinBase(BetButtonControl betControl, AutoButtonControl autoControl, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    {
        this._betControl = betControl;
        this._autoControl = autoControl;
        this._boardManager = boardManager;
        this._gameMode = gameMode;
        this._mono = mono;
    }

    public abstract void SpinHandler();

    protected virtual void Rotate()
    {
        _mono.StartCoroutine(_gameMode.GetServerData(GetInputValue()));

        _boardManager.Spin();
    }

    protected virtual void Stop()
    {
        _mono.StartCoroutine(_boardManager.Stop(_gameMode.BackendData));

    }

    protected virtual int GetInputValue() => _betControl.CurrentValue;
}