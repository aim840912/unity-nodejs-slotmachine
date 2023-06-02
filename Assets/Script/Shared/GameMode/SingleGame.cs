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

    private int[] _boardNum = new int[9];

    private int _min = 0;
    private int _max = 10;

    public SingleGame()
    {
        _fileDataHandler = new FileDataHandler(_filePath, _fileName, _encryptData);
    }

    public IEnumerator GetServerData(int betInputValue)
    {
        yield return null;

        CalcMoney(betInputValue);
    }

    private void CalcMoney(int betInputValue)
    {
        int[] boardNum = GenerateBoard();

        int currentMoney = PlayerManager.instance.GetPlayerMoney();
        int winMoney = GetMultiple(boardNum) * betInputValue / 8 - betInputValue;

        currentMoney += winMoney;

        BackendData.BoardNum = boardNum;
        BackendData.WinMoney = winMoney;
        BackendData.Money = currentMoney;

        PlayerManager.instance.PlayerData.Money = currentMoney;

        _fileDataHandler.Save(PlayerManager.instance.PlayerData);
    }


    private int[] GenerateBoard()
    {
        for (var i = 0; i < _boardNum.Length; i++)
        {
            _boardNum[i] = Random.Range(_min, _max);
        }
        return _boardNum;
    }



    private int GetMultiple(int[] boardNum)
    {
        int multiple = _calcMultiple.GetMultiples(boardNum);

        return multiple;
    }
}
