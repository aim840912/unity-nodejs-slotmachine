using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public int Money;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    public void LoadData(GameData _data)
    {
        this.Money = _data.Money;
    }

    public void SaveData(ref GameData _data)
    {
        _data.Money = this.Money;
    }
}
