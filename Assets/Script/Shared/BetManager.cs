using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetManager : MonoBehaviour
{
    private static BetManager _instance = null;

    public int BetValue { get; set; }
    public int AutoValue { get; set; }

    public static BetManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singleton = new GameObject();

                _instance = singleton.AddComponent<BetManager>();
                singleton.name = "[Singleton]" + typeof(BetManager).ToString();

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
