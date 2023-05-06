using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameMode
{
    ONLINE,
    SINGLE_GAME // 單機模式
}

[RequireComponent(typeof(Button))]
public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameMode _gameMode;
    [SerializeField] Button _button;
    [SerializeField] SceneChangeHandler _sceneChangeHandler;

    private void Reset()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(() => LoadToScene());
    }

    private void LoadToScene()
    {
        switch (_gameMode)
        {
            case GameMode.SINGLE_GAME:
                GameManager.instance.GameMode = GameMode.SINGLE_GAME;
                break;

            case GameMode.ONLINE:
                GameManager.instance.GameMode = GameMode.ONLINE;
                break;
            default:
                break;
        }

        _sceneChangeHandler.ClickToScene();
    }


}
