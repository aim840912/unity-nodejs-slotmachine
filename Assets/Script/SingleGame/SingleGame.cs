using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    public int[] SlotNumber { get; set; } = new int[9];

    public BackendData BackendData { get; set; } = new BackendData();
    [SerializeField] private SingleGameHandler _singleGameHandler;

    private CalcMultiple _calcMultiple = new CalcMultiple();

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

        _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData);
    }


    private void OnApplicationQuit()
    {
        _singleGameHandler.SaveGame(PlayerManager.instance.PlayerData);
    }

    int GetMultiple(int[] boardNum)
    {
        int multiple = _calcMultiple.GetMultiples(boardNum);
        Debug.Log($"{multiple}");

        return multiple;
    }

}
