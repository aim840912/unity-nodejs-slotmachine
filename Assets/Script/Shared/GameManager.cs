using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct StoreData
{
    public string UserId;
    public string Name;
    public int CurrentMoney;
    public int WinMoney;
    public int[] BoardNum;
}

public class GameManager : MonoBehaviour
{
    public ScenePattern _scenePattern;
    public static GameManager instance = null;
    public StoreData storeData;
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

    public void ResetAllValue()
    {
        storeData.UserId = "";
        storeData.Name = "";
        storeData.CurrentMoney = 0;
        storeData.WinMoney = 0;
    }
}
