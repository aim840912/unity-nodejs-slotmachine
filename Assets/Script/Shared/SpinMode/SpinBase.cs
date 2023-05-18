using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public abstract class SpinBase
{
    protected UiManager _uiManager;
    protected BoardManager _boardManager;
    protected IGameMode _gameMode;
    protected MonoBehaviour _mono;

    public SpinBase(UiManager uiManager, BoardManager boardManager, IGameMode gameMode, MonoBehaviour mono)
    {
        this._uiManager = uiManager;
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

    protected virtual int GetInputValue() => _uiManager._betControl.CurrentValue;
}