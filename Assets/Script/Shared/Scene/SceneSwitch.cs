using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum ScenePattern
{
    ONLINE,
    SINGLE_GAME // Personal computer 單機模式
}

[RequireComponent(typeof(Button))]
public class SceneSwitch : MonoBehaviour
{

    [SerializeField] ScenePattern _scenePattern;
    [SerializeField] Button _button;

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
        switch (_scenePattern)
        {
            case ScenePattern.SINGLE_GAME:
                GameManager.instance._scenePattern = ScenePattern.SINGLE_GAME;
                SceneManager.LoadScene("Machine Scene");
                break;

            case ScenePattern.ONLINE:
                GameManager.instance._scenePattern = ScenePattern.ONLINE;
                SceneManager.LoadScene("Login Scene");
                break;

            default:
                break;
        }
    }
}
