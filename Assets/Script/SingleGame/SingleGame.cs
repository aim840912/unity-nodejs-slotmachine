using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    public int[] SlotNumber { get; set; } = new int[9];

    public BackendData BackendData { get; set; } = new BackendData();
    private SingleGameHandler _singleGameHandler = new SingleGameHandler();
    private FileDataHandler _fileDataHandler;
    private CalcMultiple _calcMultiple = new CalcMultiple();

    [SerializeField] private string _fileName;
    [SerializeField] private bool _encryptData;

    [ContextMenu("Delete save file")]
    private void DeleteSavedData()
    {
        _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _encryptData);
        _fileDataHandler.Delete();
    }

    private void Start()
    {
        if (GameManager.Instance.GameMode == GameMode.SINGLE_GAME)
        {
            _fileDataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _encryptData);
            _singleGameHandler.LoadGame(_fileDataHandler);
            Debug.Log("loadGame()");
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

        PlayerManager.instance.PlayerData.Money = currentMoney;

        _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData, _fileDataHandler);
    }


    private void OnApplicationQuit()
    {
        if (GameManager.Instance.GameMode == GameMode.SINGLE_GAME)
            _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData, _fileDataHandler);
    }

    int GetMultiple(int[] boardNum)
    {
        int multiple = _calcMultiple.GetMultiples(boardNum);
        Debug.Log($"{multiple}");

        return multiple;
    }

}
