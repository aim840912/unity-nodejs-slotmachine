using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class SceneSwitch : MonoBehaviour
{
    public enum ScenePattern
    {
        ONLINE,
        OFFLINE
    }

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
            case ScenePattern.OFFLINE:
                SceneManager.LoadScene("Machine Scene");
                break;

            case ScenePattern.ONLINE:
                SceneManager.LoadScene("Login Scene");
                break;

            default:
                break;
        }
    }
}
