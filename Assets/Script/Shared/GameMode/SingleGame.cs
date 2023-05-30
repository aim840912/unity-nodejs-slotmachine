using System.Collections;
using UnityEngine;

public class SingleGame : IGameMode
{
    public BackendData BackendData { get; set; } = new BackendData();
    private FileDataHandler _fileDataHandler;
    private CalcMultiple _calcMultiple = new CalcMultiple();

    private string _fileName = "slotMachine";
    private bool _encryptData = true;
    private string _filePath = "idbfs/aim841104fsdfsdfsdagf";

    public SingleGame()
    {
        _fileDataHandler = new FileDataHandler(_filePath, _fileName, _encryptData);
    }

    public IEnumerator GetServerData(int betInputValue)
    {
        GenerateGameBoard(0, 10);

        yield return null;

        CalcMoney(betInputValue);
    }

    private void GenerateGameBoard(int min, int max)
    {
        int[] slotNumber = new int[9];

        for (var i = 0; i < slotNumber.Length; i++)
        {
            slotNumber[i] = Random.Range(min, max);
        }

        BackendData.BoardNum = slotNumber;
    }

    private void CalcMoney(int betInputValue)
    {
        int winMoney = 0;
        int currentMoney = PlayerManager.instance.PlayerData.Money;

        winMoney = GetMultiple(BackendData.BoardNum) * betInputValue / 8 - betInputValue;

        currentMoney += winMoney;


        BackendData.WinMoney = winMoney;
        BackendData.Money = currentMoney;

        PlayerManager.instance.PlayerData.Money = currentMoney;

        _fileDataHandler.Save(PlayerManager.instance.PlayerData);
    }


    private int GetMultiple(int[] boardNum)
    {
        int multiple = _calcMultiple.GetMultiples(boardNum);

        return multiple;
    }
}
