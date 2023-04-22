using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public int PlayerMoney = 1000;

    public PlayerData PlayerData;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this);
    }
    // public void LoadData(GameData _data)
    // {
    //     this.PlayerMoney = _data.Money;
    // }

    // public void SaveData(ref GameData _data)
    // {
    //     _data.Money = this.PlayerMoney;
    // }
}
