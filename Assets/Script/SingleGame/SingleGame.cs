using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    public int[] SlotNumber { get; set; } = new int[9];

    public BackendData BackendData { get; set; }

    [SerializeField] private string fileName;
    [SerializeField] private bool encryptData;

    private CalcMultiple _calcMultiple = new CalcMultiple();
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
        GenerateGameBoard(0, 10);

        CalcMoney(betInputValue);

        yield return null;
    }

    void GenerateGameBoard(int min, int max)
    {
        int[] slotNumber = new int[9];

        for (var i = 0; i < slotNumber.Length; i++)
        {
            slotNumber[i] = Random.Range(min, max);
        }

        BackendData.BoardNum = slotNumber;
    }

    void CalcMoney(int betInputValue)
    {
        int winMoney = 0;
        int currentMoney = PlayerManager.instance.PlayerData.Money;

        winMoney = GetMultiple(BackendData.BoardNum) * betInputValue / 8 - betInputValue;

        currentMoney += winMoney;


        BackendData.WinMoney = winMoney;
        BackendData.Money = currentMoney;


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
        BackendData = dataHandler.Load();

        if (this.BackendData == null)
        {
            Debug.Log("No saved data found!");
            NewGame();
        }

        PlayerManager.instance.PlayerData.Money = BackendData.Money;
    }

    public void NewGame()
    {
        BackendData = new BackendData();
    }
    public void SaveGame()
    {
        dataHandler.Save(BackendData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    int GetMultiple(int[] boardNum)
    {
        int multiple = _calcMultiple.GetMultiples(boardNum);
        Debug.Log($"{multiple}");

        return multiple;
    }

}
