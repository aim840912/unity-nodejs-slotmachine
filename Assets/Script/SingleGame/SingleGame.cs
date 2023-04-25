using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGame : MonoBehaviour
{
    int _currentMoney;
    public int WinMoney { get; private set; }
    public int[] SlotNumber { get; private set; } = new int[9];
    public int InputValue { get; set; } = 0;

    readonly int _minBoardNumber = 0;
    readonly int _maxBoardNumber = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();


    public void GetServerData()
    {
        GenerateGameBoard();

        CalcMoney();
    }

    void GenerateGameBoard()
    {
        for (var i = 0; i < SlotNumber.Length; i++)
        {
            SlotNumber[i] = Random.Range(_minBoardNumber, _maxBoardNumber);
        }
    }

    void CalcMoney()
    {
        WinMoney = GetMultiple() * InputValue - 8 * InputValue;

        _currentMoney = PlayerPrefs.GetInt("playerMoney") + WinMoney;
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiples(SlotNumber);
        Debug.Log($"{multiple}");

        return multiple;
    }
}
