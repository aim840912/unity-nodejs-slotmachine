using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum GameMode
{
    ONLINE,
    SINGLE_GAME,// 單機模式
    dev,
}

[RequireComponent(typeof(Button))]
public class SceneSwitch : MonoBehaviour
{
    [SerializeField] GameMode _gameMode;
    [SerializeField] Button _button;
    [SerializeField] SceneEnum _sceneEnum;

    private void Reset()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(() => LoadToScene());
    }

    public void LoadToScene()
    {
        GameManager.Instance.GameMode = _gameMode;
        if (_gameMode == GameMode.ONLINE)
        {
            if (GameManager.Instance.CheckHasInternet())
            {
                MoveToScene();
            }
        }
        else
        {
            MoveToScene();
        }

    }

    private void MoveToScene()
    {
        SceneManager.LoadScene((int)_sceneEnum);
    }
}
