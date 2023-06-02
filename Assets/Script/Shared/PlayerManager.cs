using UnityEngine;

public class BackendData
{
    public int[] BoardNum;
    public int WinMoney;
    public int Money;
}

public class PlayerData
{
    public string UserId;
    public string Name;
    public int Money = 10000;
    public PlayerData(string userId = "userId", string name = "name", int money = 10000)
    {
        this.UserId = userId;
        this.Name = name;
        this.Money = money;
    }
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;

    public PlayerData PlayerData { get; set; }

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

    public int GetPlayerMoney() => PlayerData.Money;

    public void SetPlayerData(PlayerData playerData)
    {
        this.PlayerData = playerData;
    }

    public void ResetPlayerData()
    {
        this.PlayerData.UserId = "";
        this.PlayerData.Name = "";
        this.PlayerData.Money = 0;
    }
}
