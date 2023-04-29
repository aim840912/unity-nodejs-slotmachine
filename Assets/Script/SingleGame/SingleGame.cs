using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; } = new int[9];
    public int PlayerMoney { get; set; }
    public ServerReturnData ServerReturnData { get; set; }
    public bool GetData { get; set; }

    readonly int _minBoardNumber = 0;
    readonly int _maxBoardNumber = 10;
    private CalcMultiple _calcMultiple = new CalcMultiple();


    [SerializeField] private string fileName;
    [SerializeField] private bool encryptData;

    private FileDataHandler dataHandler;

    [ContextMenu("Delete save file")]
    private void DeleteSavedData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);
        dataHandler.Delete();
    }

    private void Start()
    {
        if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
        {
            GetPlayerData();
        }
    }

    public IEnumerator GetServerData(int betInputValue)
    {
        GenerateGameBoard();

        CalcMoney(betInputValue);

        yield return null;
    }

    void GenerateGameBoard()
    {
        for (var i = 0; i < SlotNumber.Length; i++)
        {
            SlotNumber[i] = Random.Range(_minBoardNumber, _maxBoardNumber);
        }

        ServerReturnData.BoardNum = SlotNumber;
    }

    void CalcMoney(int betInputValue)
    {
        int _currentMoney = PlayerManager.instance.PlayerData.Money;

        WinMoney = GetMultiple() * betInputValue / 8 - betInputValue;

        ServerReturnData.WinMoney = WinMoney;

        _currentMoney += WinMoney;

        ServerReturnData.Money = _currentMoney;

        PlayerManager.instance.PlayerData.Money = _currentMoney;

        SaveGame();
    }

    void GetPlayerData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, encryptData);

        if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
        {
            Debug.Log("loadGame()");
            LoadGame();
        }
    }

    public void LoadGame()
    {
        ServerReturnData = dataHandler.Load();

        if (this.ServerReturnData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
        }

        PlayerManager.instance.PlayerData.Money = ServerReturnData.Money;
    }

    public void NewGame()
    {
        ServerReturnData = new ServerReturnData();
    }
    public void SaveGame()
    {
        dataHandler.Save(ServerReturnData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiples(SlotNumber);
        Debug.Log($"{multiple}");

        return multiple;
    }

}
