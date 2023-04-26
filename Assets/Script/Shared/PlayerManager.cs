using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string UserId;
    public string Name;
    public int Money;
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;

    public PlayerData PlayerData;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
