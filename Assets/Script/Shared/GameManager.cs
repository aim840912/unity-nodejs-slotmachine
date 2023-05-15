using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public GameMode GameMode { get; set; } = GameMode.ONLINE;
    public int AutoTime { get; set; } = 0;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();

                _instance = singleton.AddComponent<GameManager>();
                singleton.name = "[Singleton]" + typeof(GameManager).ToString();

                DontDestroyOnLoad(singleton);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
